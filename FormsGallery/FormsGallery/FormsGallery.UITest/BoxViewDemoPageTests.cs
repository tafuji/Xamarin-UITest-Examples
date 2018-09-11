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
    public class BoxViewDemoPageTests
    {
        IApp app;
        readonly Platform platform;

        public BoxViewDemoPageTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void BoxViewDemoPage_Test()
        {
            var mainPage = new MainPageObject(app);
            mainPage.TapTableTextCellByName("BoxView");
            for (int i = 0; i < 5; i++)
            {
                app.Tap(x => x.Marked("FormsGallery.BoxViewDemoPage.BoxView"));
            }
        }
    }
}

