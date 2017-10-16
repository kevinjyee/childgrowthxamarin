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
            Children.Add(new MainPage() { Icon = "measurements.png" });
            Children.Add(new Milestones.MilestonesListPage() { Icon = "milestones.png" });
            Children.Add(new Vaccinations.Vaccinations() { Icon = "vaccinations.png" });
            Children.Add(new Education.Education() { Icon = "education.png" });
            Children.Add(new Insights.Insights() { Icon = "insights.png" });
        }
    }

}