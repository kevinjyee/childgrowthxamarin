using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ChildGrowth.Pages.Milestones
{
    public partial class MilestonesDescriptionPage : ContentPage
    {
		MilestonesViewModel viewModel;
		Boolean answer;
        public MilestonesDescriptionPage()
        {
            InitializeComponent();
            SubmitButton.IsEnabled = false;
        }

        public MilestonesDescriptionPage(MilestonesViewModel viewModel)
		{
            InitializeComponent();
			BindingContext = this.viewModel = viewModel;
		}

        void No_Clicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            button.Image = "blue_no.png";
            YesButton.Image = "wborder_yes.png";
            answer = false;
            SubmitButton.IsEnabled = true;
        }

        void Yes_Clicked(object sender, EventArgs args)
        {
            NoButton.Image = "wborder_no.png";
            YesButton.Image = "blue_yes.png";
            answer = true;
            SubmitButton.IsEnabled = true;
        }

        void Submit_Clicked(object sender, System.EventArgs e)
        {
            
        }
    }
}
