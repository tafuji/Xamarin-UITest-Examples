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
    public class NavigationPageTests
    {
        IApp app;
        readonly Platform platform;

        public NavigationPageTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void ButtonDemoPage_Test()
        {
            var mainPage = new MainPageObject(app);
            mainPage.TapTableTextCellByName("NavigationPage");
            app.WaitForElement(x => x.Marked("NavigationPage"), timeout: TimeSpan.FromSeconds(3));
            System.Threading.Thread.Sleep(3000);
            app.Back();
        }
    }
}

