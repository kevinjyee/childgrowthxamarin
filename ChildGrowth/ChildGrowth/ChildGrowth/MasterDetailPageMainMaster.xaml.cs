using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChildGrowth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageMainMaster : ContentPage
    {
        public ListView ListView;

        public MasterDetailPageMainMaster()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPageMainMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailPageMainMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPageMainMenuItem> MenuItems { get; set; }

            public MasterDetailPageMainMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPageMainMenuItem>(new[]
                {
                    new MasterDetailPageMainMenuItem { Id = 0, Title = "Page 1" },
                    new MasterDetailPageMainMenuItem { Id = 1, Title = "Page 2" },
                    new MasterDetailPageMainMenuItem { Id = 2, Title = "Page 3" },
                    new MasterDetailPageMainMenuItem { Id = 3, Title = "Page 4" },
                    new MasterDetailPageMainMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}