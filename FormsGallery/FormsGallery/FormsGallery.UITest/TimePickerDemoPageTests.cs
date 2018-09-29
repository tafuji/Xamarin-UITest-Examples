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
    public class TimePickerDemoPageTests
    {
        IApp app;
        readonly Platform platform;

        private static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(30);
        private const string iOSTableViewClass = "UIPickerTableView";

        public TimePickerDemoPageTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void TimePickerDemoPage_Test()
        {
            var mainPage = new MainPageObject(app);
            mainPage.TapTableTextCellByName("TimePicker");

            var hour = 11;
            var minutes = 59;
            var meridian = "PM";
            var mark = "TimePickerDemoPage.TimePicker";

            if (platform == Platform.Android)
            {
                app.Tap(x => x.Marked(mark));
                app.WaitForElement(x => x.Id("timePicker"));

                app.Query(x => x.Id("timePicker").Invoke("setHour", hour + 12));
                app.Query(x => x.Id("timePicker").Invoke("setMinute", minutes));

                app.Tap(x => x.Id("button1")); //Ok Button in DatePicker Dialogue
            }
            else if(platform == Platform.iOS)
            {
                //Activate the DatePicker
                app.Tap(x => x.Id(mark));

                // Wait for DatePicker animation to completed
                app.WaitForElement(x => x.Class("UIPickerView"));

                // DatePicker items
                app.ScrollDownTo(z => z.Marked(hour.ToString()), x => x.Class(iOSTableViewClass).Index(0), timeout: DefaultTimeout, strategy: ScrollStrategy.Auto);
                app.Tap(x => x.Text(hour.ToString()));

                app.ScrollDownTo(z => z.Marked(minutes.ToString()), x => x.Class(iOSTableViewClass).Index(3), timeout: DefaultTimeout, strategy: ScrollStrategy.Auto);
                app.Tap(x => x.Text(minutes.ToString()));

                app.ScrollDownTo(z => z.Marked(meridian), x => x.Class(iOSTableViewClass).Index(6), timeout: DefaultTimeout, strategy: ScrollStrategy.Auto);
                app.Tap(x => x.Text(meridian));

                app.Tap(x => x.Marked("Done")); // Done をタップする
            }
        }
    }
}

