using System;
using System.Globalization;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace FormsGallery.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class DatePickerDemoPageTests
    {
        IApp app;
        readonly Platform platform;

        private static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(30);

        public DatePickerDemoPageTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void DatePickerDemoPage_Test()
        {
            var mainPage = new MainPageObject(app);
            mainPage.TapTableTextCellByName("DatePicker");

            var date = new DateTime(2018, 12, 23);
            CultureInfo enus = new CultureInfo("en-US");
            var month = enus.DateTimeFormat.GetMonthName(date.Month);
            var expected = date.ToString("D", enus);
            var actual = string.Empty;

            var mark = "DatePickerDemoPage.DatePicker";
            if (platform == Platform.Android)
            {
                app.Tap(x => x.Marked(mark));

                //Wait for DatePicker animation to completed
                app.WaitForElement(x => x.Class("DatePicker"));

                //Invoke updateDate() method on displayed DatePicker
                app.Query(x => x.Class("DatePicker").Invoke("updateDate", date.Year, date.Month -1, date.Day));

                //Tap the ok button to close the DatePicker dialogue
                app.Tap(x => x.Id("button1")); //Ok Button in DatePicker Dialogue
            }
            else if(platform == Platform.iOS)
            {
                //Activate the DatePicker
                app.Tap(x => x.Id(mark));

                // Wait for DatePicker animation to completed
                app.WaitForElement(x => x.Class("UIPickerView"));

                // Scroll DatePicker items
                string iOSTableViewClass = "UIPickerTableView";
                app.ScrollDownTo(z => z.Marked(month), x => x.Class(iOSTableViewClass).Index(0), timeout: DefaultTimeout, strategy: ScrollStrategy.Auto);
                app.Tap(x => x.Text(month));

                app.ScrollDownTo(z => z.Marked(date.Day.ToString()), x => x.Class(iOSTableViewClass).Index(3), timeout: DefaultTimeout, strategy: ScrollStrategy.Auto);
                app.Tap(x => x.Text(date.Day.ToString()));

                app.ScrollDownTo(z => z.Marked(date.Year.ToString()), x => x.Class(iOSTableViewClass).Index(6), timeout: DefaultTimeout, strategy: ScrollStrategy.Auto);
                app.Tap(x => x.Text(date.Year.ToString()));

                app.Tap(x => x.Marked("Done")); // Tap button marked with "Done".
            }
        }
    }
}

