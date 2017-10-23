using System;
using System.Collections.Generic;
using ChildGrowth.Pages.AddChild;
using Xamarin.Forms;

namespace ChildGrowth.Pages.Menu
{
    public partial class MenuMasterPage : ContentPage
    {
        public MenuMasterPage()
        {
            InitializeComponent();
        }

        async void Add_Children_Handler(object sender, EventArgs e)
        {
            var childEntryPage = new ChildEntry();
            await Navigation.PushModalAsync(childEntryPage);

        }
    }
}
