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

        public Education(Child C)
        {
            currentChild = C;
            this.Title = currentChild.Name;
            InitializeComponent();
            InitializeComponent();
        }

        async void BehaviorButtonClick(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new EducationInfo("Behavior"));
        }

        async void LearningButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EducationInfo("Learning"));
        }

        async void SafetyButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EducationInfo("Safety"));
        }

        async void PlayButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EducationInfo("Play"));
        }

        async void ToiletTrainingButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EducationInfo("Toilet"));
        }

        async void DiseasesButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EducationInfo("Diseases"));
        }

        async void DoctorVisitsButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EducationInfo("Doctor"));
        }
        
       
    }
}