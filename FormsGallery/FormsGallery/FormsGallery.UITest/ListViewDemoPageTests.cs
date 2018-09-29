using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace FormsGallery.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class ListViewDemoPageTests
    {
        IApp app;
        readonly Platform platform;

        public ListViewDemoPageTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void ListViewDemoPage_Test()
        {
            var mainPage = new MainPageObject(app);
            mainPage.TapTableTextCellByName("ListView");

            var mark = "ListViewDemoPage.ListView";
            var nameLabelMark = "ListViewDemoPage.NameLabel";

            app.ScrollDownTo(z => z.Marked(nameLabelMark).Text("Yvonne"), x => x.Marked(mark), timeout: TimeSpan.FromSeconds(30), strategy: ScrollStrategy.Auto);

            var nameLabels = app.Query(x => x.Marked(nameLabelMark));
            var birthdayLabels = app.Query(x => x.Marked("ListViewDemoPage.BirthDayLabel"));
        }

        [Test]
        public void ListViewDemoPageReflesh_Test()
        {
            var mainPage = new MainPageObject(app);
            mainPage.TapTableTextCellByName("ListView");

            var marked = "ListViewDemoPage.ListView";
            app.WaitForElement(x => x.Marked(marked));

            // Get the centeral coordinate of the first cell in ListView.
            AppResult firstCellInList = null;
            if(platform == Platform.Android)
            {
                firstCellInList = app.Query(x => x.Class("ViewCellRenderer_ViewCellContainer").Index(0)).FirstOrDefault();
            }
            else if (platform == Platform.iOS)
            {
                firstCellInList = app.Query(x => x.Class("Xamarin_Forms_Platform_iOS_ViewCellRenderer_ViewTableCell")).FirstOrDefault();
            }

            var firstCenterX = firstCellInList.Rect.CenterX;
            var firstCenterY = firstCellInList.Rect.CenterY;

            // Get the central coordinate of the ListView.
            var listview = app.Query(x => x.Marked(marked))[0];
            var listviewCenterX = listview.Rect.CenterX;
            var listviewCenterY = listview.Rect.CenterY;

            // Drag from the center of the first cell to the center of the ListView
            app.DragCoordinates(firstCenterX, firstCenterY, listviewCenterX, listviewCenterY);

            // Wait for the indicator disappering
            WaitForIndicatorToDisappear(3, 10);
        }

        public bool RefreshIndicatorIsDisplayed
        {
            get
            {
                if (platform == Platform.Android)
                    return (bool)app.Query(x => x.Class("SwipeRefreshLayout").Invoke("isRefreshing")).First();

                if (platform == Platform.iOS)
                    return (bool)app.Query(x => x.Class("UIRefreshControl")).Any();

                throw new Exception("Platform Not Recognized");
            }
        }

        public void WaitForIndicatorToDisappear(int retryCount = 3, int waitSeconds = 10)
        {
            int counter = 0;
            while (RefreshIndicatorIsDisplayed)
            {
                Thread.Sleep(waitSeconds * 1000);
                counter++;

                if (counter >= retryCount)
                    throw new Exception($"Loading the list took longer than {waitSeconds * retryCount}");
            }
        }
    }
}

