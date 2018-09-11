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
    public class LabelDemoPageTests
    {
        IApp app;
        readonly Platform platform;

        public LabelDemoPageTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void LabelDemoPage_Test()
        {
            var mainPage = new MainPageObject(app);
            mainPage.TapTableTextCellByName("Label");

            string initial = "Welcome to Xamarin.Forms!";
            string replaced = "Hello Xamarin.Forms!";
            string actual = string.Empty;
            app.WaitForElement(x => x.Marked(initial), timeout: TimeSpan.FromSeconds(30));


            if(platform == Platform.Android)
            {
                app.Query(x => x.Marked(initial).Invoke("setText", replaced));
                actual = app.Query(x => x.Marked(replaced))[0].Text;
            }
            else if(platform == Platform.iOS)
            {
                app.Query(x => x.Marked(initial).Invoke("Text", replaced));
                actual = app.Query(x => x.Marked(replaced))[0].Text;
            }
            Assert.That(replaced == actual);
        }
    }
}

