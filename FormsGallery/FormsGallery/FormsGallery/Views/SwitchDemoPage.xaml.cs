using FormsGallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsGallery
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwitchDemoPage : ContentPage
    {
        public SwitchDemoPage()
        {
            InitializeComponent();
            this.BindingContext = new SwitchDemoPageViewModel();
        }
    }
}