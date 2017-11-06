using System;
using System.Collections.Generic;
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
        public MenuMasterDetailPage()
        {
            InitializeComponent();
            MainPage = (new NavigationPage(new MainPage()){ Icon = "measurements.png", Title = "Measurements" });
            Milestones = (new NavigationPage(new Milestones.Milestones()) { Icon = "milestones.png", Title = "Milestones" });
            Vaccinations = (new NavigationPage(new Vaccinations.Vaccinations()){ Icon = "vaccinations.png", Title = "Vaccinations" });
            Education = (new NavigationPage(new Education.Education()) { Icon = "education.png", Title = "Education" });
            Insights = (new NavigationPage(new Insights.Insights()) { Icon = "insights.png", Title = "Insights" }); 

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
                UpdateChild(C);


            };
        }

        async private void UpdateChild(Child child){
            ContextDatabaseAccess database = new ContextDatabaseAccess();
            await database.InitializeAsync();
            Context currentContext = database.GetContextAsync().Result;
            if (currentContext == null){
                currentContext = new Context(child.GetID(), Language.ENGLISH, new Units(DistanceUnits.IN, WeightUnits.OZ));
                await database.SaveContextAsync(currentContext);
            }
            else{
                currentContext.ChildId = child.GetID();
                await database.SaveContextAsync(currentContext);
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

        override
        protected void OnAppearing()
        {
            UpdateChildList();
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
            }
        }
    }
}