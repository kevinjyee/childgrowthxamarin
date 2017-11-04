using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChildGrowth.Pages.Settings;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChildGrowth.Pages.Insights
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Insights : ContentPage
    {
        private Child currentChild { get; set; }
        public Insights()
        {
            InitializeComponent();
        }
        public Insights(Child C){
            currentChild = C;
            this.Title = currentChild.Name;
            InitializeComponent();
        }
        void OnSettingsClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }
    }
}