using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.BehaviorsPack;

namespace FormsGallery.ViewModels
{
    public class MasterDetailPageDemoPageViewModel : ViewModelBase
    {
        INavigation navigation;

        private bool isPresented = false;

        public bool IsPresented
        {
            get => isPresented;
            set
            {
                isPresented = value;
                OnPropertyChanged();
            }
        }

        public Command<NamedColor> SelectedColorCommand { get; }

        public ObservableCollection<NamedColor> ColorList { get; } = new ObservableCollection<NamedColor>()
        {
            new NamedColor ("Aqua", Color.Aqua),
            new NamedColor ("Black", Color.Black),
            new NamedColor ("Blue", Color.Blue),
            new NamedColor ("Fuchsia", Color.Fuchsia),
            new NamedColor ("Gray", Color.Gray),
            new NamedColor ("Green", Color.Green),
            new NamedColor ("Lime", Color.Lime),
            new NamedColor ("Maroon", Color.Maroon),
            new NamedColor ("Navy", Color.Navy),
            new NamedColor ("Olive", Color.Olive),
            new NamedColor ("Purple", Color.Purple),
            new NamedColor ("Red", Color.Red),
            new NamedColor ("Silver", Color.Silver),
            new NamedColor ("Teal", Color.Teal),
            new NamedColor ("White", Color.White),
            new NamedColor ("Yellow", Color.Yellow)
        };

        public MasterDetailPageDemoPageViewModel(INavigation navi)
        {
            navigation = navi;
            SelectedColorCommand = new Command<NamedColor>(SelectedColorDetail);
        }

        private async void SelectedColorDetail(NamedColor e)
        {
            var nextPage = new NamedColorPage();
            nextPage.BindingContext = e;
            IsPresented = false;
            await navigation.PushAsync(nextPage);
        }
    }

    public class NamedColor
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public double Red { get => Color.R; }
        public double Green { get => Color.G; }
        public double Blue { get => Color.B; }
        public double Hue { get => Color.Hue; }
        public double Saturation { get => Color.Saturation; }
        public double Luminosity { get => Color.Luminosity; }

        public NamedColor(string name, Color color)
        {
            Name = name;
            Color = color;
        }
    }
}
