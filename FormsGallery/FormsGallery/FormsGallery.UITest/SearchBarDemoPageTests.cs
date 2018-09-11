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
    public class SearchBarDemoPageTests
    {
        IApp app;
        readonly Platform platform;

        public SearchBarDemoPageTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void SearchBarDemoPage_Test()
        {
            var mainPage = new MainPageObject(app);
            mainPage.TapTableTextCellByName("SearchBar");
            var mark = "SearchBarDemoPage.SearchBar";

            // SearchBar に検索条件を入力する
            app.EnterText(x => x.Marked(mark), "Title");
            app.PressEnter();

            // SearchBar のテキストをクリアする
            app.ClearText(x => x.Marked(mark));
            app.DismissKeyboard();

            // SearchBar のキャンセルボタンを押す
            app.EnterText(x => x.Marked(mark), "WrongCondition");
            if (platform == Platform.Android)
            {
                app.Tap(x => x.Id("search_close_btn"));
            }
            else if (platform == Platform.iOS)
            {
                app.Tap(x => x.Marked("Cancel"));
            }
            app.DismissKeyboard();
        }
    }
}

