using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ChildGrowth.Pages.Milestones;

namespace ChildGrowth.Pages.Master
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterTab : TabbedPage
    {
        public MasterTab()
        {
            InitializeComponent();
            Children.Add(new NavigationPage(new MainPage()) { Icon = "measurements.png" });
            Children.Add(new NavigationPage(new Milestones.Milestones()) { Icon = "milestones.png" });
            Children.Add(new NavigationPage(new Vaccinations.Vaccinations()) { Icon = "vaccinations.png" });
            Children.Add(new NavigationPage(new Education.Education()) { Icon = "education.png" });
            Children.Add(new NavigationPage(new Insights.Insights()) { Icon = "insights.png" });
        }
    }
}