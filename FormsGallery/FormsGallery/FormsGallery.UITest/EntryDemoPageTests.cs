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
    public class EntryDemoPageTests
    {
        IApp app;
        readonly Platform platform;

        public EntryDemoPageTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void EntryDemoPage_Test()
        {
            var mainPage = new MainPageObject(app);
            mainPage.TapTableTextCellByName("Entry (single line)");

            var mailId = "EntryDemoPage.MailEntry";
            var passwordId = "EntryDemoPage.Password";
            var phoneNumberId = "EntryDemoPage.PhoneNumber";

            //EnterText
            app.EnterText(x => x.Marked(mailId), "someone@somewhere.local");
            app.DismissKeyboard();

            app.EnterText(x => x.Marked(passwordId), "safepassword");
            app.DismissKeyboard();

            app.EnterText(x => x.Marked(phoneNumberId), "123-4567-9012");
            app.DismissKeyboard();

            //ClearText
            app.ClearText(x => x.Marked(mailId));
            app.DismissKeyboard();

            app.ClearText(x => x.Marked(passwordId));
            app.DismissKeyboard();

            app.ClearText(x => x.Marked(phoneNumberId));
            app.DismissKeyboard();
        }
    }
}

