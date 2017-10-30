using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChildGrowth.Pages.Education
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Education : ContentPage
    {
        private Child currentChild { get; set; }
        public Education()
        {
            InitializeComponent();
        }

        public Education(Child C){
            currentChild = C;
            this.Title = currentChild.Name;
            InitializeComponent();
        }
    }
}