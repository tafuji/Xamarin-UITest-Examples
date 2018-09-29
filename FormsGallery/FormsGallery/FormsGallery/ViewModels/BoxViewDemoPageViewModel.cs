using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsGallery.ViewModels
{
    public class BoxViewDemoPageViewModel : ViewModelBase
    {
        public Command TapCommand { get; set; }

        private int _count;
        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
                OnPropertyChanged();
            }
        }

        public BoxViewDemoPageViewModel()
        {
            TapCommand = new Command(() => { Count++; });
        }
    }
}
