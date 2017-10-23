using System;
using System.Collections.Generic;
using ChildGrowth.Pages.AddChild;
using ChildGrowth.Pages.Master;
using ChildGrowth.Persistence;
using Xamarin.Forms;

namespace ChildGrowth.Pages.Menu
{
    public partial class MenuMasterDetailPage : MasterDetailPage
    {
        public MenuMasterDetailPage()
        {
            InitializeComponent();
            TabbedPage.Children.Add(new NavigationPage(new MainPage()) { Icon = "measurements.png", Title = "Measurements" });
            TabbedPage.Children.Add(new NavigationPage(new Milestones.Milestones()) { Icon = "milestones.png", Title = "Milestones" });
            TabbedPage.Children.Add(new NavigationPage(new Vaccinations.Vaccinations()) { Icon = "vaccinations.png", Title = "Vaccinations" });
            TabbedPage.Children.Add(new NavigationPage(new Education.Education()) { Icon = "education.png", Title = "Education" });
            TabbedPage.Children.Add(new NavigationPage(new Insights.Insights()) { Icon = "insights.png", Title = "Insights" });
            UpdateChildList();
        }

        async private void UpdateChildList()
        {
            ChildDatabaseAccess childDatabase = new ChildDatabaseAccess();
            await childDatabase.InitializeAsync();
            List<Child> children = childDatabase.GetAllUserChildrenAsync().Result;
            List<String> names = new List<string>();
            foreach(Child kid in children){
                String name = kid.Name;
                names.Add(name);
            }
            this.ChildList.ItemsSource = names;
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
    }
}