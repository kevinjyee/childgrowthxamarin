using Syncfusion.DataSource;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChildGrowth.Pages.Milestones
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MilestonesListPage : ContentPage
    {
        public MilestonesListPage()
        {
            InitializeComponent();   
        }

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			var item = args.SelectedItem as Milestone;
			if (item == null)
				return;

            await Navigation.PushAsync(new MilestonesDescriptionPage(new MilestonesViewModel(item)));

			// Manually deselect item
			MilestonesListView.SelectedItem = null;
		}
    }
}   