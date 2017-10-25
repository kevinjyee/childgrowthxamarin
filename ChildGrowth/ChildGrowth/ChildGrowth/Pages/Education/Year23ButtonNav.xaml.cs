using ChildGrowth.Models.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChildGrowth.Pages.Education
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Year23ButtonNav : ContentPage
    {
        public Year23ButtonNav()
        {
            InitializeComponent();
        }
        async void GeneralButtonClick(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationYear23Category.Y3GENERAL.ToString()));
        }
        async void BehaviorButtonClick(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationYear23Category.Y3BEHAVIOR.ToString()));
        }
        async void MilestonesY3ButtonClick(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationYear23Category.Y3MILESTONES.ToString()));
        }
    }
}