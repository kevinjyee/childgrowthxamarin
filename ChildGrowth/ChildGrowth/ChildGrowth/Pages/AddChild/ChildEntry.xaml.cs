using ChildGrowth.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Child;

namespace ChildGrowth.Pages.AddChild
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChildEntry : ContentPage
	{
		public ChildEntry ()
		{
			InitializeComponent ();
		}
        async void AddChildButton_Clicked(object sender, EventArgs e)
        {

            string nameEntered = nameEntry.Text;

            DateTime birthdayEntered = birthdayEntry.Date;

            Gender genderSelected = newChildGender;

            Boolean missingInfo = false;

            if (nameEntered == null || nameEntered == "")
            {
                await DisplayAlert("Failed", "Please Enter your child's Name", "OK");
                missingInfo = true;
            }
            else if (birthdayEntered == null)
            {
                await DisplayAlert("Failed", "Please Enter your child's birthday.", "OK");
                missingInfo = true;
            }
            else if (genderSelected == Gender.UNSPECIFIED)
            {
                await DisplayAlert("Failed", "Please Enter your child's sex.", "OK");
                missingInfo = true;
            }
            if(missingInfo)
            {
                return;
            }
            else
            {
                ChildDatabaseAccess childDatabase = new ChildDatabaseAccess();
                await childDatabase.InitializeAsync();
                Child newChild = new Child(nameEntered, birthdayEntered, genderSelected);
                await childDatabase.SaveUserChildAsync(newChild);
            }

            await Navigation.PopModalAsync();
        }

        private void MaleButton_Clicked(object sender, EventArgs e)
        {
            newChildGender = Gender.MALE;
        }

        private void FemaleButton_Clicked(object sender, EventArgs e)
        {
            newChildGender = Gender.FEMALE;
        }

        private static Gender newChildGender = Gender.UNSPECIFIED;
    }
}