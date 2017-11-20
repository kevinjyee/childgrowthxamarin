using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChildGrowth.Models.Settings;
using ChildGrowth.Pages.AddChild;
using ChildGrowth.Pages.Master;
using ChildGrowth.Persistence;
using Xamarin.Forms;

namespace ChildGrowth.Pages.Menu
{
    public partial class MenuMasterDetailPage : MasterDetailPage
    {
        
        private Page MainPage { get; set; }
        private static MainPage CastMainPage { get; set; }
        private Page Milestones { get; set; }
        private static Milestones.Milestones CastMilestonesPage { get; set; }
        private Page Vaccinations { get; set; }
        private static Vaccinations.Vaccinations CastVaccinationsPage { get; set; }
        private Page Education { get; set; }
        private static Education.Education CastEducationPage { get; set; }
        private Page Insights { get; set; }
        private static Insights.Insights CastInsightsPage { get; set; }
        private static ChildEntry CastChildEntryPage { get; set; }
        private static EditChild CastEditChildPage { get; set; }
        private Context CurrentContext { get; set; }

        public MenuMasterDetailPage()
        {
            InitializeComponent();
            CastMainPage = new MainPage(this);
            CastMilestonesPage = new Milestones.Milestones();
            CastVaccinationsPage = new Vaccinations.Vaccinations();
            CastEducationPage = new Education.Education(this);
            CastInsightsPage = new Insights.Insights(this);
            if (CurrentContext == null)
            {
                CurrentContext = Context.LoadCurrentContext();
            }
            if (CurrentContext.CurrentLanguage == Language.ENGLISH)
            {
                MainPage = (new NavigationPage(CastMainPage) { Icon = "measurements.png", Title = "Measurements" });
                Milestones = (new NavigationPage(CastMilestonesPage) { Icon = "milestones.png", Title = "Milestones" });
                Vaccinations = (new NavigationPage(CastVaccinationsPage) { Icon = "vaccinations.png", Title = "Vaccinations" });
                Education = (new NavigationPage(CastEducationPage) { Icon = "education.png", Title = "Education" });
                Insights = (new NavigationPage(CastInsightsPage) { Icon = "insights.png", Title = "Insights" });
            }
            else
            {
                MainPage = (new NavigationPage(CastMainPage) { Icon = "measurements.png", Title = "Medidas" });
                Milestones = (new NavigationPage(CastMilestonesPage) { Icon = "milestones.png", Title = "Hito" });
                Vaccinations = (new NavigationPage(CastVaccinationsPage) { Icon = "vaccinations.png", Title = "Vacunas" });
                Education = (new NavigationPage(new Education.Education()) { Icon = "education.png", Title = "Educación" });
                Insights = (new NavigationPage(CastInsightsPage) { Icon = "insights.png", Title = "Resumen" });  
            }
            TabbedPage.Children.Add(MainPage);
            TabbedPage.Children.Add(Milestones);
            TabbedPage.Children.Add(Vaccinations);
            TabbedPage.Children.Add(Education);
            TabbedPage.Children.Add(Insights);
            UpdateChildList();

            ChildList.ItemSelected += (sender, e) =>
            {
                ((ListView)sender).SelectedItem = null;
                var C = (Child) e.SelectedItem;
                Task Update = Task.Run(async () => 
                {
                    try
                    {
                        await UpdateChild(C);
                    }
                    catch(ObjectDisposedException exc)
                    {
                        // TODO:
                    }
                });
                Update.Wait();
                IsPresented = false;
            };

            ChildList.ItemTapped += (Sender, Event) =>
            {
                var C = (Child)Event.Item;
                Task Update = Task.Run(async () =>
                {
                    try
                    {
                        await UpdateChild(C);
                    }
                    catch (ObjectDisposedException exc)
                    {
                        // TODO:
                    }
                });
                try
                {
                    Update.Wait();
                }
                catch
                {

                }
                IsPresented = false;
            };
        }

        void NotifyPagesOfChildUpdate(Child c)
        {
            CastMainPage.CurrentChild = c;
            CastMilestonesPage.CurrentChild = c;
            CastVaccinationsPage.CurrentChild = c;
            CastInsightsPage.CurrentChild = c;
        }

        void NotifyPagesOfLanguageUpdate(Language language)
        {
            CastMainPage.CurrentLanguage = language;
            CastEducationPage.CurrentLanguage = language;
            CastInsightsPage.CurrentLanguage = language;
            if(CastEditChildPage != null)
            {
                CastEditChildPage.CurrentLanguage = language;
            }
            if(CastChildEntryPage != null)
            {
                CastChildEntryPage.CurrentLanguage = language;
            }
        }

        async private Task<Boolean> UpdateChild(Child child)
        {
            Context CurrentContext;
            ContextDatabaseAccess contextDB = new ContextDatabaseAccess();
            contextDB.InitializeSync();
            try
            {
                CurrentContext = contextDB.GetContextSync();
            }
            // Can't find definitions for SQLiteNetExtensions exceptions, so catch generic Exception e and assume there is no context.
            catch (Exception e)
            {
                CurrentContext = null;
            }
            if (CurrentContext == null)
            {
                if (child == null)
                {
                    CurrentContext = new Context(-1, Language.ENGLISH, new Units(DistanceUnits.IN, WeightUnits.OZ));
                }
                else
                {
                    CurrentContext = new Context(child.GetID(), Language.ENGLISH, new Units(DistanceUnits.IN, WeightUnits.OZ));
                }
                NotifyPagesOfChildUpdate(child);
                contextDB.SaveContextSync(CurrentContext);
                contextDB.CloseSyncConnection();
                return true;
            }
            else
            {
                if (child == null)
                {
                    CurrentContext.ChildId = -1;
                }
                else
                {
                    CurrentContext.ChildId = child.GetID();
                }
                NotifyPagesOfChildUpdate(child);
                contextDB.SaveContextSync(CurrentContext);
                contextDB.CloseSyncConnection();
                return true;
            }
        }

        async private void UpdateChildList()
        {
            ChildDatabaseAccess childDatabase = new ChildDatabaseAccess();
            await childDatabase.InitializeAsync();
            List<Child> children = childDatabase.GetAllUserChildrenAsync().Result;
            this.ChildList.ItemsSource = children;
        }

        async void Add_Children_Handler(object sender, EventArgs e)
        {
            var childEntryPage = new ChildEntry();
            await Navigation.PushModalAsync(childEntryPage);
        }

        async private Task SetContext()
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
            }
            if (CurrentContext == null)
            {
                CurrentContext = new Context(-1, Language.ENGLISH, new Units(DistanceUnits.IN, WeightUnits.OZ));
            }
            await contextDB.SaveContextAsync(CurrentContext);
        }

        protected override void OnDisappearing()
        {
            Task set = Task.Run(async () => { await SetContext(); });
            set.Wait();
            if (CurrentContext.CurrentLanguage == Language.ENGLISH)
            {
                SetEnglish();
            }
            else
            {
                SetSpanish();
            }
            UpdateChildList();
        }

        override
        protected void OnAppearing()
        {
            Task set = Task.Run(async () => { await SetContext(); });
            set.Wait();
            if (CurrentContext.CurrentLanguage == Language.ENGLISH)
            {
                SetEnglish();
            }
            else 
            {
                SetSpanish();
            }
            UpdateChildList();
        }

        public void UpdateLanguage(Language language)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if(language == Language.ENGLISH)
                {
                    SetEnglish();
                }
                else
                {
                    SetSpanish();
                }
                NotifyPagesOfLanguageUpdate(language);
            });
        }

        private void SetEnglish()
        {
            ListTitle.Text = "Children";
            AddButton.Text = "Add New Children";
            MainPage.Title = "Measurements";
            Milestones.Title = "Milestones";
            Vaccinations.Title = "Vaccinations";
            Education.Title = "Education";
            Insights.Title = "Insights";
        }

        private void SetSpanish()
        {
            ListTitle.Text = "Niños";
            AddButton.Text = "Añadir un nuevo niño";
            MainPage.Title = "Medidas";
            Milestones.Title = "Hito";
            Vaccinations.Title = "Vacunas";
            Education.Title = "Educación";
            Insights.Title = "Resumen";
        }

        async void OnEdit(object sender, System.EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            Child C = (Child)item.CommandParameter;
            await Navigation.PushModalAsync(new EditChild(C));
        }

        async void OnDelete(object sender, System.EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            Child C = (Child)item.CommandParameter;
            var alert = await DisplayAlert("Warning", "Are You Sure You Want To Delete Child: " + C.Name, "Delete", "Cancel");
            if (alert.Equals(true))
            {
                var try1 = item.GetType();
                ChildDatabaseAccess childDatabase = new ChildDatabaseAccess();
                await childDatabase.InitializeAsync();
                await childDatabase.DeleteUserChildAsync(C);
                UpdateChildList();
                await Task.Run(async () => { await UpdateChild(null); });
            }
        }
    }
}