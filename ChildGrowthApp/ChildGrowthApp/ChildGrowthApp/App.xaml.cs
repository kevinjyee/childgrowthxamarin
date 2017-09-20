using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ChildGrowthApp
{
    public partial class App : Application
    {
        public static IList<string> PhoneNumbers { get; set; }

        public App()
        {
            InitializeComponent();
            PhoneNumbers = new List<string>();
            MainPage = new NavigationPage(new MainPage());
        }
       
    }
}