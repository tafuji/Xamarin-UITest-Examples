using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsGallery.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        INavigation navigation;

        private readonly string namespaceName = "FormsGallery";

        public MainPageViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            NavigateCommand = new Command<string>(PushAsync);
        }

        public Command<string> NavigateCommand { get; private set; }

        private async void PushAsync(string pageName)
        {
            Type type = Type.GetType($"{namespaceName}.{pageName}");
            Page page = (Page)Activator.CreateInstance(type);
            await navigation.PushAsync(page);
        }
    }
}
