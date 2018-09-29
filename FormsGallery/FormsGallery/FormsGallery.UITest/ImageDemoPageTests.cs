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
    public class ImageDemoPageTests
    {
        IApp app;
        readonly Platform platform;

        public ImageDemoPageTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void ImageDemoPage_Test()
        {
            var mainPage = new MainPageObject(app);
            mainPage.TapTableTextCellByName("Image");

            string imageMark = "ImageDemoPage.Image";
            app.WaitForElement(x => x.Marked(imageMark), timeout: TimeSpan.FromSeconds(30));
            var image = app.Query(x => x.Marked(imageMark));
        }
    }
}

