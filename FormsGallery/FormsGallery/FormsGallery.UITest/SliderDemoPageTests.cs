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
    public class SliderDemoPageTests
    {
        IApp app;
        readonly Platform platform;

        public SliderDemoPageTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void SliderDemoPage_Test()
        {
            var mainPage = new MainPageObject(app);
            mainPage.TapTableTextCellByName("Slider (double)");

            string marked = "SliderDemoPage.Slider";
            if(platform == Platform.Android)
            {
                var progress = 500.0;
                app.SetSliderValue(marked, progress);
                var actual = Convert.ToDouble(app.Query(x => x.Marked(marked).Invoke("getProgress"))[0]);
                Assert.That(progress == actual);
            }
            else if(platform == Platform.iOS)
            {
                var progress = 50;
                app.SetSliderValue(marked, progress);
                var actual = Convert.ToInt32(app.Query(x => x.Class("UISlider").Invoke("value"))[0]);
                Assert.That(progress == actual);
            }
        }
    }
}

