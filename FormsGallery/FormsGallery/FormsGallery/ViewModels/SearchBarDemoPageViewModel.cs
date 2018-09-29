using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsGallery.ViewModels
{
    public class SearchBarDemoPageViewModel : ViewModelBase
    {
        private string _searchWord;

        public string SearchWord
        {
            get => _searchWord;
            set
            {
                _searchWord = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TypeInformation> _result = new ObservableCollection<TypeInformation>();

        public ObservableCollection<TypeInformation> Result { get => _result; set => _result = value; }

        public Command<string> SearchCommand { get; set; }

        public SearchBarDemoPageViewModel()
        {
            SearchCommand = new Command<string>(Search);
        }

        private void Search(string searchWord)
        {
            Result.Clear();
            Assembly xamarinFormsAssembly = typeof(View).GetTypeInfo().Assembly;
            foreach (Type type in xamarinFormsAssembly.ExportedTypes)
            {
                TypeInfo typeInfo = type.GetTypeInfo();

                if (typeInfo.IsPublic)
                {
                    foreach (PropertyInfo property in typeInfo.DeclaredProperties)
                    {
                        if (property.Name.Equals(searchWord))
                        {
                            var item = new TypeInformation()
                            {
                                TypeName = typeInfo.Name,
                                PropertyTypeName = property.PropertyType.Name
                            };
                            Result.Add(item);
                        }
                    }
                }
            }

            if (!Result.Any())
            {
                Result.Add(new TypeInformation() { TypeName = "No results", PropertyTypeName = "No results" });
            }
        }

    }

    public class TypeInformation
    {
        public string TypeName { get; set; }

        public string PropertyTypeName { get; set; }
    }
}
