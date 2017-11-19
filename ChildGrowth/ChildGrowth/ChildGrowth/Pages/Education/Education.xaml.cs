using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChildGrowth.Models.Settings;
using ChildGrowth.Pages.Settings;
using ChildGrowth.Persistence;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChildGrowth.Pages.Education
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Education : ContentPage
    {
        private Child CurrentChild { get; set; }
        private Context CurrentContext { get; set; }

        public Education()
        {
            InitializeComponent();

        }

        override
        protected void OnAppearing()
        {
            Task Load = Task.Run(async () => { await LoadContext(); });
            Load.Wait();
            if (CurrentChild != null)
            {
                this.Title = CurrentChild.Name;
            }
            else
            {
                this.Title = "Please Select a Child";
            }
        }

        private async Task<Boolean> LoadContext()
        {
            ContextDatabaseAccess contextDB = new ContextDatabaseAccess();
            await contextDB.InitializeAsync();
            try
            {
                CurrentContext = contextDB.GetContextAsync().Result;
            }
            // Can't find definitions for SQLiteNetExtensions exceptions, so catch generic Exception e and assume there is no context.
            catch (Exception e)
            {
                CurrentContext = null;
                //contextDB.CloseSyncConnection();
            }
            // If context doesn't exist, create it, save it, and populate vaccine/milestones databases.
            if (CurrentContext == null)
            {
                CurrentContext = new Context();
                // Exception probably broke the synchronous connection.
                //contextDB.InitializeSync();
                ContextDatabaseAccess newContextDB = new ContextDatabaseAccess();
                await newContextDB.InitializeAsync();
                newContextDB.SaveFirstContextAsync(CurrentContext);
                //newContextDB.CloseSyncConnection();
                CurrentChild = null;
                Task tVaccine = VaccineTableConstructor.ConstructVaccineTable();
                Task tMilestone = MilestonesTableConstructor.ConstructMilestonesTable();
                await tVaccine;
                await tMilestone;
                return true;
            }
            else
            {
                CurrentChild = CurrentContext.GetSelectedChild();
                return true;
            }
        }

        void OnSettingsClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
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