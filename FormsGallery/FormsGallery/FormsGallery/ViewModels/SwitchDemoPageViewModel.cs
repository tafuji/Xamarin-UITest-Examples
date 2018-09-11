using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsGallery.ViewModels
{
    public class SwitchDemoPageViewModel : ViewModelBase
    {
        private bool _value;
        public bool Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }
    }
}
