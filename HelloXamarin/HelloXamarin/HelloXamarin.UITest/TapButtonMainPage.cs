using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace HelloXamarin.UITest
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class TapButtonMainPage
    {
        IApp app;
        Platform platform;

        public TapButtonMainPage(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void TabButtonAndHelloUITestDisplay()
        {
            app.Tap(c => c.Marked("MainPage.Button"));
            AppResult[] results = app.WaitForElement(c => c.Marked("Hello, Xamarin UITest!"));
            Assert.IsTrue(results.Any());
        }
    }
}
