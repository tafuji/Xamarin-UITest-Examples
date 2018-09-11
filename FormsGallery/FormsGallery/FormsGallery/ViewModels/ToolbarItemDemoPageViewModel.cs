using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsGallery.ViewModels
{
    public class ToolbarItemDemoPageViewModel : ViewModelBase
    {
        public Command<string> ClickCommand { get; private set; }

        private string _text = "";
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        public ToolbarItemDemoPageViewModel()
        {
            ClickCommand = new Command<string>(Click);
        }

        private void Click(string text)
        {
            this.Text = text;
        }
    }
}
