using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChildGrowth.Pages.Child
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChildEntry : ContentPage
	{
		public ChildEntry ()
		{
			InitializeComponent ();
		}
        async void onClick_loginButton(object sender, EventArgs e)
        {

            string nameEntered = nameEntry.Text;

            string birthdayEntered = birthdayEntry.Date.ToString("yyyy-MM-dd");



            if (nameEntered == null || nameEntered == "")
            {

                await DisplayAlert("Failed", "Please Enter your child's Name", "OK");

                return;

            }

            await Navigation.PopModalAsync();
        }
    }
}