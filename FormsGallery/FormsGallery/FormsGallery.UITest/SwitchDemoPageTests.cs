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
    public class SwitchDemoPageTests
    {
        IApp app;
        readonly Platform platform;

        public SwitchDemoPageTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void SwitchDemoPage_Test()
        {
            var mainPage = new MainPageObject(app);
            mainPage.TapTableTextCellByName("Switch (bool)");

            string marked = "SwitchDemoPage.Switch";
            app.Tap(x => x.Marked(marked));
            if (platform == Platform.Android)
            {
                var result = (bool)app.Query(x => x.Marked(marked).Invoke("isChecked"))[0];
                Assert.That(result == true);

                // switch by invoke method
                app.Query(x => x.Marked(marked).Invoke("setChecked", false));
            }
            else if(platform == Platform.iOS)
            {
                // Switch が ON の時は、1 が返される
                // Switch が OFF の時は、0 が返される
                var result = Convert.ToInt32(app.Query(x => x.Marked(marked).Invoke("isOn"))[0]);
                Assert.That(result == 1);

                // switch by invoke method
                app.Query(x => x.Marked(marked).Invoke("setOn:animated", 0));
            }
        }
    }
}

