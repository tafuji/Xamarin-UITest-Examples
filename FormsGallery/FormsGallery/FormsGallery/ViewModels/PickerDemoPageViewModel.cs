using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsGallery.ViewModels
{
    public class PickerDemoPageViewModel : ViewModelBase
    {
        private static Dictionary<string, Color> NameToColor = new Dictionary<string, Color>
        {
            { "Aqua", Color.Aqua },         { "Black", Color.Black },
            { "Blue", Color.Blue },         { "Fuchsia", Color.Fuchsia },
            { "Gray", Color.Gray },         { "Green", Color.Green },
            { "Lime", Color.Lime },         { "Maroon", Color.Maroon },
            { "Navy", Color.Navy },         { "Olive", Color.Olive },
            { "Purple", Color.Purple },     { "Red", Color.Red },
            { "Silver", Color.Silver },     { "Teal", Color.Teal },
            { "White", Color.White },       { "Yellow", Color.Yellow }
        };

        public ObservableCollection<string> PickerItems { get =>  new ObservableCollection<string>(NameToColor.Keys); }

        private Color _boxColor;

        public Color BoxColor {
            get
            {
                return _boxColor;
            }
            set
            {
                _boxColor = value;
                OnPropertyChanged();
            }
        }

        public string _selectedColor = "White";
        public string SelectedColor
        {
            get
            {
                return _selectedColor;
            }
            set
            {
                _selectedColor = value;
                OnPropertyChanged();
                BoxColor = NameToColor[value];
            }
        }

        public PickerDemoPageViewModel()
        {

        }
    }
}
