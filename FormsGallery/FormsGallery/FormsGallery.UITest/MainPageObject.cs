using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace FormsGallery.UITest
{
    public class MainPageObject
    {
        private Func<AppQuery, AppQuery> TableTextCell(string id) => e => e.Marked(id);

        private readonly IApp _app;

        public MainPageObject(IApp app)
        {
            _app = app;
        }

        public void TapTableTextCellByName(string markedText)
        {
            _app.ScrollDownTo(x => x.Marked(markedText), strategy: ScrollStrategy.Auto);
            _app.WaitForElement(x => x.Marked(markedText), timeout: TimeSpan.FromSeconds(30));
            _app.Tap(TableTextCell(markedText));
        }
    }
}
