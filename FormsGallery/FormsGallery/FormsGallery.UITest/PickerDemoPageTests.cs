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
    public class PickerDemoPageTests
    {
        IApp app;
        readonly Platform platform;

        TimeSpan DefaultTimeout = TimeSpan.FromSeconds(30);

        public PickerDemoPageTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void PickerDemoPage_Test()
        {
            var mainPage = new MainPageObject(app);
            mainPage.TapTableTextCellByName("Picker");

            var marked = "PickerDemoPage.Picker";
            app.Tap(x => x.Marked(marked));

            if (platform == Platform.Android)
            {
                app.ScrollDownTo(z => z.Marked("Yellow"), 
                                 x => x.Id("select_dialog_listview"), 
                                 timeout: TimeSpan.FromSeconds(30), 
                                 strategy: ScrollStrategy.Auto);
                app.Tap(x => x.Marked("Yellow"));
            }
            else if(platform == Platform.iOS)
            {
                app.ScrollUpTo(z => z.Marked("Aqua"),
                               x => x.Class("UIPickerTableView").Index(0),
                               timeout: DefaultTimeout,
                               strategy: ScrollStrategy.Auto);
                app.Tap(x => x.Marked("Aqua"));
                app.Tap(x => x.Marked("Done")); // Done をタップする
            }
        }
    }
}

