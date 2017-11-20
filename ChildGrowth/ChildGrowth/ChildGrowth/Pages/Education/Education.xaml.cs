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
using ChildGrowth.Pages.Menu;
using System.ComponentModel;

namespace ChildGrowth.Pages.Education
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Education : ContentPage, INotifyPropertyChanged
    {
        private MenuMasterDetailPage MasterPage { get; set; }
        private Language _currentLanguage { get; set; }
        private Child CurrentChild { get; set; }
        private Context CurrentContext { get; set; }

        public Language CurrentLanguage
        {
            get
            {
                return _currentLanguage;
            }
            set
            {
                if (value != _currentLanguage)
                {
                    OnPropertyChanged("CurrentLanguage");
                }
                if (value == Language.ENGLISH)
                {
                    _currentLanguage = value;
                    SetEnglish();
                }
                else
                {
                    SetSpanish();
                }
            }
        }

        public Education()
        {
            InitializeComponent();

        }

        public Education(MenuMasterDetailPage Page)
        {
            InitializeComponent();
            MasterPage = Page;
        }

        override
        protected void OnAppearing()
        {
            Task Load = Task.Run(async () => { await LoadContext(); });
            Load.Wait();
            if (CurrentContext.CurrentLanguage == Language.ENGLISH)
            {
                SetEnglish();
            } else
            {
                SetSpanish();
            }
            if (CurrentChild != null)
            {
                this.Title = CurrentChild.Name;
            }
            else
            {
                if (CurrentContext.CurrentLanguage == Language.ENGLISH)
                {
                    this.Title = "Please Select a Child";
                }
                else
                {
                    this.Title = "Porfavor Seleccione un Niño";
                }
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

        private void SetEnglish()
        {
            PageTitle.Text = "Education Page";
            BehaviorButton.Source = ImageSource.FromFile("behavior.png");
            LearningButton.Source = ImageSource.FromFile("learning.png");
            SafetyButton.Source = ImageSource.FromFile("safety.png");
            PlayButton.Source = ImageSource.FromFile("play.png");
            ToiletButton.Source = ImageSource.FromFile("toilet_training.png");
            DiseasesButton.Source = ImageSource.FromFile("diseases.png");
            DoctorButton.Source = ImageSource.FromFile("doctor_visits.png");
        }

        private void SetSpanish()
        {
            PageTitle.Text = "Pagina de Educacion";
            BehaviorButton.Source = ImageSource.FromFile("behavior_sp.png");
            LearningButton.Source = ImageSource.FromFile("learning_sp.png");
            SafetyButton.Source = ImageSource.FromFile("safety_sp.png");
            PlayButton.Source = ImageSource.FromFile("play_sp.png");
            ToiletButton.Source = ImageSource.FromFile("toilet_training_sp.png");
            DiseasesButton.Source = ImageSource.FromFile("diseases_sp.png");
            DoctorButton.Source = ImageSource.FromFile("doctor_visits_sp.png");
        }

        void OnSettingsClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage(MasterPage));
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