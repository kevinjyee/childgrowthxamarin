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
        private Page Milestones { get; set; }
        private Page Vaccinations { get; set; }
        private Page Education { get; set; }
        private Page Insights { get; set; }
        private Context CurrentContext { get; set; }

        public MenuMasterDetailPage()
        {
            InitializeComponent();
            Task Set = Task.Run(async () => { await SetContext(); });
            Set.Wait();
            if (CurrentContext.CurrentLanguage == Language.ENGLISH)
            {
                MainPage = (new NavigationPage(new MainPage()) { Icon = "measurements.png", Title = "Measurements" });
                Milestones = (new NavigationPage(new Milestones.Milestones()) { Icon = "milestones.png", Title = "Milestones" });
                Vaccinations = (new NavigationPage(new Vaccinations.Vaccinations()) { Icon = "vaccinations.png", Title = "Vaccinations" });
                Education = (new NavigationPage(new Education.Education()) { Icon = "education.png", Title = "Education" });
                Insights = (new NavigationPage(new Insights.Insights()) { Icon = "insights.png", Title = "Insights" });
            }
            else
            {
                MainPage = (new NavigationPage(new MainPage()) { Icon = "measurements.png", Title = "Medidas" });
                Milestones = (new NavigationPage(new Milestones.Milestones()) { Icon = "milestones.png", Title = "Alcances" });
                Vaccinations = (new NavigationPage(new Vaccinations.Vaccinations()) { Icon = "vaccinations.png", Title = "Vacunas" });
                Education = (new NavigationPage(new Education.Education()) { Icon = "education.png", Title = "Educación" });
                Insights = (new NavigationPage(new Insights.Insights()) { Icon = "insights.png", Title = "Resumen" });  
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
            };

            ChildList.ItemTapped += (Sender, Event) =>
            {
                var C = (Child)Event.Item;
                Task Update = Task.Run(async () => { await UpdateChild(C); });
                Update.Wait();
                IsPresented = false;
            };
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

        async private Task<Boolean> UpdateChild(Child child){
            ContextDatabaseAccess contextDB = new ContextDatabaseAccess();
            await contextDB.InitializeAsync();
            CurrentContext.ChildId = child.GetID();
            await contextDB.SaveContextAsync(CurrentContext);
            return true;
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

        private void SetEnglish()
        {
            ListTitle.Text = "Children";
            AddButton.Text = "Add New Children";

        }

        private void SetSpanish()
        {
            ListTitle.Text = "Niños";
            AddButton.Text = "Añadir un nuevo niño";
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