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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EducationButtonNav : ContentPage
    {
        public EducationButtonNav()
        {
            InitializeComponent();
        }

        async void BehaviorButtonClick(object sender, EventArgs args)
        {
           await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationCategory.BEHAVIOR.ToString()));
        }

        async void LearningButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationCategory.LEARNING.ToString()));
        }

        async void SafetyButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationCategory.SAFETY.ToString()));
        }

        async void PlayButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationCategory.PLAY.ToString()));
        }

        async void ToiletTrainingButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationCategory.TOILET_TRAINING.ToString()));
        }

        async void DiseasesButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationCategory.DISEASES.ToString()));
        }

        async void DoctorVisitsButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationCategory.DOCTOR_VISITS.ToString()));
        }

        async void Year01ButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationCategory.YEAR01.ToString()));
        }

        async void Year12ButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationCategory.YEAR12.ToString()));
        }

        async void Year23ButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationCategory.YEAR23.ToString()));
        }
    }
}