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
    public class ProgressBarDemoPageTests
    {
        IApp app;
        readonly Platform platform;

        public ProgressBarDemoPageTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void ProgressBarDemoPage_Test()
        {
            var mainPage = new MainPageObject(app);
            mainPage.TapTableTextCellByName("ProgressBar");

            if (platform == Platform.Android)
            {
                //Sets ProgressBar to 50%, 100% = 10,000
                System.Threading.Thread.Sleep(1000);
                app.Query(x => x.Class("ProgressBar").Invoke("setProgress", 2500));

                System.Threading.Thread.Sleep(1000);
                app.Query(x => x.Class("ProgressBar").Invoke("setProgress", 5000));

                System.Threading.Thread.Sleep(1000);
                app.Query(x => x.Class("ProgressBar").Invoke("setProgress", 7500));

                System.Threading.Thread.Sleep(1000);
                app.Query(x => x.Class("ProgressBar").Invoke("setProgress", 10000));
            }
            else if (platform == Platform.iOS)
            {
                //Sets ProgressBar to 50%, 100% = 1.0f
                System.Threading.Thread.Sleep(1000);
                app.Query(x => x.Class("UIProgressView").Invoke("setProgress:animated", 0.25));

                System.Threading.Thread.Sleep(1000);
                app.Query(x => x.Class("UIProgressView").Invoke("setProgress:animated", 0.5));

                System.Threading.Thread.Sleep(1000);
                app.Query(x => x.Class("UIProgressView").Invoke("setProgress:animated", 0.75));

                System.Threading.Thread.Sleep(1000);
                app.Query(x => x.Class("UIProgressView").Invoke("setProgress:animated", 1.0));
            }
        }
    }
}

