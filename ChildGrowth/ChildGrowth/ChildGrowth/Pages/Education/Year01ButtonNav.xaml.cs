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
    public partial class Year01ButtonNav : ContentPage
    {
        public Year01ButtonNav()
        {
            InitializeComponent();
        }

        async void GeneralButtonClick(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationYear01Category.Y1GENERAL.ToString()));
        }
        async void BreastfeedingButtonClick(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationYear01Category.Y1BREASTFEEDING.ToString()));
        }
        async void FeedingNutritionButtonClick(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationYear01Category.Y1FEEDINGNUTRITION.ToString()));
        }
        async void SleepButtonClick(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationYear01Category.Y1SLEEP.ToString()));
        }
        async void TeethingButtonClick(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationYear01Category.Y1TEETHING.ToString()));
        }
        async void BathingSkincareButtonClick(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationYear01Category.Y1BATHINGSKINCARE.ToString()));
        }
        async void DiapersClothingButtonClick(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationYear01Category.Y1DIAPERSCLOTHING.ToString()));
        }
        async void MilestonesY1ButtonClick(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationYear01Category.Y1MILESTONES.ToString()));
        }
    }
}