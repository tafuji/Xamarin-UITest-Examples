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
    public class MasterDetailPageDemoPageTest
    {
        IApp app;
        readonly Platform platform;

        public MasterDetailPageDemoPageTest(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void MasterDetailPageDemoPage_Test()
        {
            var mainPage = new MainPageObject(app);
            mainPage.TapTableTextCellByName("MasterDetailPage");

            if(platform == Platform.Android)
            {
                app.Tap(x => x.Class("AppCompatImageButton").Marked("OK"));
            }
            else if (platform == Platform.iOS)
            {
                app.Tap(x => x.Marked("hamburger")); // Tap control marked with icon name
            }

            app.ScrollDownTo(x => x.Marked("ColorListPage.ColorLabel").Text("Yellow"), x => x.Marked("ColorListPage.ListView"), timeout: TimeSpan.FromSeconds(30), strategy: ScrollStrategy.Auto);
            app.Tap(x => x.Marked("ColorListPage.ColorLabel").Text("Yellow"));

            System.Threading.Thread.Sleep(5000);

            app.Back();
        }
    }
}

