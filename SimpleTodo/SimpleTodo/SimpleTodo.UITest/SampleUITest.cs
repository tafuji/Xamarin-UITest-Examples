using System;
using System.Globalization;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace SimpleTodo.UITest
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class SampleUITest
    {
        IApp app;
        Platform platform;

        public SampleUITest(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void TapMenuAndDisplayDetail()
        {
            TapHumburgarMenu(app, "About");
            app.WaitForElement(x => x.Marked("AboutPage.Button"), 
                timeout: TimeSpan.FromSeconds(10));

            app.Screenshot("About Page");

            TapHumburgarMenu(app, "Browse");
            app.WaitForElement(x => x.Marked("ItemsPage.TodoList"), 
                timeout: TimeSpan.FromSeconds(10));

            app.Screenshot("Browse Page").CopyTo("BrowsePage.png");

            app.ScrollDownTo(x => x.Marked("Item.Title").Text("本 📚 を買う"), x => x.Marked("ItemsPage.TodoList"), timeout: TimeSpan.FromSeconds(10), strategy: ScrollStrategy.Auto);
            app.Tap(x => x.Marked("Item.Title").Text("本 📚 を買う"));

            AppResult[] detailResults = app.Query(x => x.Marked("ItemDetailPage.Title").Text("本 📚 を買う"));
            Assert.IsTrue(detailResults.Any());
            app.Screenshot("Detail Page");

            System.Threading.Thread.Sleep(3000); // Wait for a while (demo)

            app.Back();
        }

        [Test]
        public void AddNewItem()
        {
            app.Tap("Add");
            app.ClearText("NewItemPage.Title");
            app.EnterText("NewItemPage.Title" , "ジョギングをする");

            // Picker
            var date = DateTime.Now.AddDays(15);
            CultureInfo enus = new CultureInfo("en-US");
            var month = enus.DateTimeFormat.GetMonthName(date.Month);

            var mark = "NewItemPage.DatePicker";
            if (platform == Platform.Android)
            {
                app.Tap(x => x.Marked(mark));

                //Wait for DatePicker animation to completed
                app.WaitForElement(x => x.Class("DatePicker"));

                //Invoke updateDate() method on displayed DatePicker
                app.Query(x => x.Class("DatePicker").Invoke("updateDate", date.Year, date.Month - 1, date.Day));

                //Tap the ok button to close the DatePicker dialogue
                app.Tap(x => x.Id("button1")); //Ok Button in DatePicker Dialogue
            }
            else if (platform == Platform.iOS)
            {
                //Activate the DatePicker
                app.Tap(x => x.Id(mark));

                // Wait for DatePicker animation to completed
                app.WaitForElement(x => x.Class("UIPickerView"));

                // Scroll DatePicker items
                string iOSTableViewClass = "UIPickerTableView";
                app.ScrollDownTo(z => z.Marked(month), x => x.Class(iOSTableViewClass).Index(0), strategy: ScrollStrategy.Auto);
                app.Tap(x => x.Text(month));

                app.ScrollDownTo(z => z.Marked(date.Day.ToString()), x => x.Class(iOSTableViewClass).Index(3), strategy: ScrollStrategy.Auto);
                app.Tap(x => x.Text(date.Day.ToString()));

                app.ScrollDownTo(z => z.Marked(date.Year.ToString()), x => x.Class(iOSTableViewClass).Index(6), strategy: ScrollStrategy.Auto);
                app.Tap(x => x.Text(date.Year.ToString()));

                app.Tap(x => x.Marked("Done")); // Tap button marked with "Done".
            }

            // Description
            app.ClearText("NewItemPage.Description");
            app.EnterText("NewItemPage.Description", "10km 走ること");

            // Dismiss keyboard
            app.DismissKeyboard();

            // Tap SAVE button
            app.Tap("Save");

            // Assertion
            app.WaitForElement(x => x.Marked("ItemsPage.TodoList"), timeout: TimeSpan.FromSeconds(10));
            app.ScrollDownTo(x => x.Marked("Item.Title").Text("ジョギングをする"), x => x.Marked("ItemsPage.TodoList"), timeout: TimeSpan.FromSeconds(10), strategy: ScrollStrategy.Auto);
            app.Screenshot("Add New Item");
        }

        [Test]
        public void Repl()
        {
            app.Repl();
        }


        private void TapHumburgarMenu(IApp app, string menu)
        {
            if (platform == Platform.Android)
            {
                app.Tap(x => x.Class("AppCompatImageButton").Marked("OK"));
            }
            else if (platform == Platform.iOS)
            {
                app.Tap(x => x.Marked("hamburger")); // Tap control marked with icon name
            }
            app.WaitForElement(x => x.Marked("MenuPage.MenuLabel").Text(menu), timeout: TimeSpan.FromSeconds(10));
            app.Screenshot(menu);
            app.Tap(x => x.Marked(menu));
        }
    }
}
