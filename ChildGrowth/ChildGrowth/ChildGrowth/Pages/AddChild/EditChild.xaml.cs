using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChildGrowth.Models.Settings;
using ChildGrowth.Persistence;
using Xamarin.Forms;
using static Child;

namespace ChildGrowth.Pages.AddChild
{
    public partial class EditChild : ContentPage
    {
        private Context CurrentContext { get; set; }
        public EditChild()
        {
            InitializeComponent();
        }

        private Child childToEdit { get; set; }

        private void SetSpanish()
        {
            Title.Text = "Editar Nino";
            NameLabel.Text = "Nombre:";
            BirthLabel.Text = "Fecha de Nacimiento:";
            SexLabel.Text = "Sexo:";
            SaveChildButton.Text = "Guardar";
        }

        private void SetEnglish()
        {
            Title.Text = "Edit Child";
            NameLabel.Text = "Name:";
            BirthLabel.Text = "Date of Birth:";
            SexLabel.Text = "Sex:";
            SaveChildButton.Text = "Save";
        }


        public EditChild(Child c)
        {
            InitializeComponent();
            childToEdit = c;
            Task Load = Task.Run(async () => { await LoadContext(); });
            Load.Wait();
            if (CurrentContext.CurrentLanguage == Language.ENGLISH){
                SetEnglish();
            } else {
                SetSpanish();
            }
            nameEntry.Text = childToEdit.Name;
            birthdayEntry.Date = childToEdit.Birthday;
            if (childToEdit.ChildGender == Gender.MALE)
            {
                SexEntry.SelectedItem = "Male";
            }
            else
            {
                SexEntry.SelectedItem = "Female";
            }

        }

        private async Task LoadContext()
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
            // If context doesn't exist, create it, save it, and populate milestones databases.
            if (CurrentContext == null)
            {
                CurrentContext = new Context();
                // Exception probably broke the synchronous connection.
                //contextDB.InitializeSync();
                ContextDatabaseAccess newContextDB = new ContextDatabaseAccess();
                await newContextDB.InitializeAsync();
                newContextDB.SaveFirstContextAsync(CurrentContext);
            }
        }

        private static Gender newChildGender = Gender.UNSPECIFIED;

        async void SaveButton_Clicked(object sender, EventArgs e)
        {

            string nameEntered = nameEntry.Text;

            DateTime birthdayEntered = birthdayEntry.Date;

            Boolean missingInfo = false;

            int index = SexEntry.SelectedIndex;

            string sex;

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
            else if (SexEntry.SelectedIndex == -1)
            {
                await DisplayAlert("Failed", "Please Enter your child's sex.", "OK");
                missingInfo = true;
            }
            if (missingInfo)
            {
                return;
            }
            else
            {
                sex = (string)SexEntry.ItemsSource[index];
                if (sex == "Male")
                {
                    newChildGender = Gender.MALE;

                }
                else
                {
                    newChildGender = Gender.FEMALE;
                }
                Gender genderSelected = newChildGender;
                childToEdit.Name = nameEntered;
                childToEdit.Birthday = birthdayEntered;
                childToEdit.ChildGender = genderSelected;
                ChildDatabaseAccess childDatabase = new ChildDatabaseAccess();
                childDatabase.InitializeSync();
                childDatabase.SaveUserChildSync(childToEdit);
                childDatabase.CloseSyncConnection();
                ContextDatabaseAccess contextDB = new ContextDatabaseAccess();
                contextDB.InitializeSync();
                Context context = contextDB.GetContextSync();
                context.ChildId = childToEdit.ID;
                contextDB.SaveContextSync(context);
                contextDB.CloseSyncConnection();
            }
            await Navigation.PopModalAsync();
        }
    }
}
