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
    public class ToolbarItemDemoPageTests
    {
        IApp app;
        readonly Platform platform;

        public ToolbarItemDemoPageTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void ToolbarItemDemoPage_Test()
        {
            var mainPage = new MainPageObject(app);
            mainPage.TapTableTextCellByName("ToolbarItem");

            if (platform == Platform.Android)
            {
                app.Tap(x => x.Marked("ToolBar1"));
                app.Tap(x => x.Marked("ToolBar2"));
            }
            else if(platform == Platform.iOS)
            {
                app.Tap(x => x.Id("ToolbarItemDemoPage.Item1"));
                app.Tap(x => x.Id("ToolbarItemDemoPage.Item2"));
            }
        }
    }
}

