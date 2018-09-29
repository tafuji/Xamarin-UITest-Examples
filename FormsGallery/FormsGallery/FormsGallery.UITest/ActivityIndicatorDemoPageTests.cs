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
    public class ActivityIndicatorDemoPageTests
    {
        IApp app;
        readonly Platform platform;

        public ActivityIndicatorDemoPageTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void ActivityIndicatorDemoPage_Test()
        {
            var mainPage = new MainPageObject(app);
            mainPage.TapTableTextCellByName("ActivityIndicator");

            string mark = "ActivityIndicatorDemoPage.ActivityIndicator";
            app.WaitForElement(x => x.Marked(mark), timeout: TimeSpan.FromSeconds(30));
            System.Threading.Thread.Sleep(5000);

            if(platform == Platform.Android)
            {
                app.Query(x => x.Marked(mark).Invoke("setVisibility", 8));
                app.WaitForNoElement(x => x.Marked(mark), timeout: TimeSpan.FromSeconds(30));
            }
            else if(platform == Platform.iOS)
            {
                app.Query(x => x.Marked(mark).Invoke("stopAnimating"));
                app.WaitForNoElement(x => x.Marked(mark), timeout: TimeSpan.FromSeconds(30));
            }
        }
    }
}

