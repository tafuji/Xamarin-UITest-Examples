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
    public class CarouselPageDemoPageTests
    {
        IApp app;
        readonly Platform platform;

        public CarouselPageDemoPageTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void CarouselPageDemoPage_Test()
        {
            var mainPage = new MainPageObject(app);
            mainPage.TapTableTextCellByName("CarouselPage");

            string page1Button = "FormsGallery.Page1.Button";
            string page2Button = "FormsGallery.Page2.Button";
            string page3Button = "FormsGallery.Page3.Button";

            app.SwipeRightToLeft();
            app.WaitForElement(x => x.Marked(page2Button), timeout: TimeSpan.FromSeconds(30));
            app.Tap(x => x.Marked(page2Button));

            app.SwipeRightToLeft();
            app.WaitForElement(x => x.Marked(page3Button), timeout: TimeSpan.FromSeconds(30));
            app.Tap(x => x.Marked(page3Button));

            app.SwipeLeftToRight();
            app.WaitForElement(x => x.Marked(page2Button), timeout: TimeSpan.FromSeconds(30));
            app.Tap(x => x.Marked(page2Button));

            app.SwipeLeftToRight();
            app.WaitForElement(x => x.Marked(page1Button), timeout: TimeSpan.FromSeconds(30));
            app.Tap(x => x.Marked(page1Button));
        }
    }
}

