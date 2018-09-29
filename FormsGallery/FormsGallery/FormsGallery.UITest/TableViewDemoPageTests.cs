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
    public class TableViewDemoPageTests
    {
        IApp app;
        readonly Platform platform;

        public TableViewDemoPageTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void TableViewDemoPage_Test()
        {
            var mainPage = new MainPageObject(app);
            mainPage.TapTableTextCellByName("TableView for a form");


            // TextCell
            var textCellText = app.Query(x => x.Marked("Text Cell"));
            var textCellDetail = app.Query(x => x.Marked("With Detail Text"));


            // Entry Cell

            // Enter text.
            var inputText = "This is text for test.";
            if(platform == Platform.Android)
            {
                app.EnterText(x => x.Class("EntryCellView").Child(1), inputText);
                app.EnterText(x => x.Class("EntryCellView").Child("EntryCellEditText"), inputText);

                app.DismissKeyboard();

            }
            else if (platform == Platform.iOS)
            {
                app.EnterText(x => x.Class("Xamarin_Forms_Platform_iOS_EntryCellRenderer_EntryCellTableViewCell").Child(0).Child(0), inputText);
                app.EnterText(x => x.Class("Xamarin_Forms_Platform_iOS_EntryCellRenderer_EntryCellTableViewCell").Child("UITableViewCellContentView").Child("UITextField"), inputText);
                app.DismissKeyboard();
            }

            System.Threading.Thread.Sleep(3000);


            // Clear text.
            if (platform == Platform.Android)
            {
                app.ClearText(x => x.Class("EntryCellView").Child(1));
            }
            else if (platform == Platform.iOS)
            {
                app.ClearText(x => x.Class("Xamarin_Forms_Platform_iOS_EntryCellRenderer_EntryCellTableViewCell").Child(0).Child(0));
            }

            // SwitchCell
            if (platform == Platform.Android)
            {
                app.Query(x => x.Class("SwitchCellView").Class("Switch").Invoke("setChecked", true));
            }
            else if (platform == Platform.iOS)
            {
                app.Query(x => x.Class("Xamarin_Forms_Platform_iOS_CellTableViewCell").Class("UISwitch").Invoke("setOn:animated", true));
            }

            System.Threading.Thread.Sleep(3000);


            // ImageCell
            if (platform == Platform.Android)
            {
                app.Query(x => x.Class("TextCellRenderer_TextCellView").Class("ImageView"));
            }
            else if(platform == Platform.iOS)
            {
                app.Query(x => x.Class("Xamarin_Forms_Platform_iOS_CellTableViewCell").Child("UITableViewCellContentView").Class("UIImageView"));
            }
        }
    }
}

