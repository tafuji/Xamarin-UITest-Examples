using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsGallery.ViewModels
{
    public class ButtonDemoPageViewModel : ViewModelBase
    {
        public Command ClickCommand { get; private set; }

        private int _clickCount = 0;
        public int ClickCount
        {
            get
            {
                return _clickCount;
            }
            set
            {
                _clickCount = value;
                OnPropertyChanged();
            }
        }

        public ButtonDemoPageViewModel()
        {
            ClickCommand = new Command(Click);
        }

        private void Click()
        {
            ClickCount += 1;
        }
    }
}
