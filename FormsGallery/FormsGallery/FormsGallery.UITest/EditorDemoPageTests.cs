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
    public class EditorDemoPageTests
    {
        IApp app;
        readonly Platform platform;

        public EditorDemoPageTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void EditorDemoPage_Test()
        {
            var mainPage = new MainPageObject(app);
            mainPage.TapTableTextCellByName("Editor (multiple lines)");

            var marked = "EditorDemoPage.Editor";

            //EnterText
            var longText = 
                @"abcdefg
hijk
lmn
opq
rstu
vwxyz";

            app.EnterText(x => x.Marked(marked), longText);
            app.DismissKeyboard();

            //ClearText
            app.ClearText(x => x.Marked(marked));
            app.DismissKeyboard();
        }
    }
}

