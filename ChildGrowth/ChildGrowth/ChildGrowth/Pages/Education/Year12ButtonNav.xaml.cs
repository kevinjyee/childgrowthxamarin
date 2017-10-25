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
    public partial class Year12ButtonNav : ContentPage
    {
        public Year12ButtonNav()
        {
            InitializeComponent();
        }
        async void GeneralButtonClick(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationYear12Category.Y2GENERAL.ToString()));
        }
        async void FeedingNutritionButtonClick(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationYear12Category.Y2FEEDINGNUTRITION.ToString()));
        }
        async void MilestonesY2ButtonClick(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationYear12Category.Y2MILESTONES.ToString()));
        }
    }
}