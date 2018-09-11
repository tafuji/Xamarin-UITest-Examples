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
    public class StepperDemoPageTests
    {
        IApp app;
        readonly Platform platform;

        public StepperDemoPageTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void StepperDemoPage_Test()
        {
            var mainPage = new MainPageObject(app);
            mainPage.TapTableTextCellByName("Stepper (double)");

            if(platform == Platform.Android)
            {
                for(int i = 0; i < 5; i++)
                {
                    app.Tap(x => x.Class("android.widget.Button").Text("+"));
                }
                for (int i = 0; i < 5; i++)
                {
                    app.Tap(x => x.Class("android.widget.Button").Text("-"));
                }
            }
            else if(platform == Platform.iOS)
            {
                for (int i = 0; i < 5; i++)
                {
                    app.Tap(x => x.Marked("Increment"));
                }
                for (int i = 0; i < 5; i++)
                {
                    app.Tap(x => x.Marked("Decrement"));
                }
            }
        }
    }
}

