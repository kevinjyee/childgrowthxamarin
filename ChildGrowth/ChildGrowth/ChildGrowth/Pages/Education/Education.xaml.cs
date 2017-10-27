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
        public Education()
        {
            InitializeComponent();
        }

        async void BehaviorButtonClick(object sender, EventArgs args)
        {
           // await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationCategory.BEHAVIOR.ToString()));
        }

        async void LearningButtonClick(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationCategory.LEARNING.ToString()));
        }

        async void SafetyButtonClick(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationCategory.SAFETY.ToString()));
        }

        async void PlayButtonClick(object sender, EventArgs e)
        {
           // await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationCategory.PLAY.ToString()));
        }

        async void ToiletTrainingButtonClick(object sender, EventArgs e)
        {
           // await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationCategory.TOILET_TRAINING.ToString()));
        }

        async void DiseasesButtonClick(object sender, EventArgs e)
        {
           // await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationCategory.DISEASES.ToString()));
        }

        async void DoctorVisitsButtonClick(object sender, EventArgs e)
        {
           // await Navigation.PushModalAsync(new EducationInfoDisplay(Models.Education.EducationCategory.DOCTOR_VISITS.ToString()));
        }
        // with the yearXX clicks, need to reroute to button page
        async void Year01ButtonClick(object sender, EventArgs e)
        {
           // var year01ButtonNavPage = new Year01ButtonNav();

           // await Navigation.PushModalAsync(year01ButtonNavPage);
        }

        async void Year12ButtonClick(object sender, EventArgs e)
        {
           // var year12ButtonNavPage = new Year12ButtonNav();

            //await Navigation.PushModalAsync(year12ButtonNavPage);
        }

        async void Year23ButtonClick(object sender, EventArgs e)
        {
            //var year23ButtonNavPage = new Year23ButtonNav();

           // await Navigation.PushModalAsync(year23ButtonNavPage);
        }
    }
}