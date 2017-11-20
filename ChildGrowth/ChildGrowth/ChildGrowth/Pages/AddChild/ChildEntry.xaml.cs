using ChildGrowth.Models.Settings;
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
        private Language _currentLanguage { get; set; }

        public Language CurrentLanguage
        {
            get
            {
                return _currentLanguage;
            }
            set
            {
                if (value != _currentLanguage)
                {
                    OnPropertyChanged("CurrentLanguage");
                }
                if (value == Language.ENGLISH)
                {
                    _currentLanguage = value;
                    SetEnglish();
                }
                else
                {
                    SetSpanish();
                }
            }
        }

        private Context CurrentContext { get; set; }

        public ChildEntry()
        {
            Task Load = Task.Run(async () => { await LoadContext(); });
            Load.Wait();
            InitializeComponent();
        }
        private void SetSpanish()
        {
            Title.Text = "Agregar Niño";
            NameLabel.Text = "Nombre:";
            BirthLabel.Text = "Fecha de Nacimiento:";
            SexLabel.Text = "Sexo:";
            AddChildButton.Text = "Guardar";
        }

        private void SetEnglish()
        {
            Title.Text = "Edit Child";
            NameLabel.Text = "Name:";
            BirthLabel.Text = "Date of Birth:";
            SexLabel.Text = "Sex:";
            AddChildButton.Text = "Save";
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

        async void AddChildButton_Clicked(object sender, EventArgs e)
        {

            string nameEntered = nameEntry.Text;

            DateTime birthdayEntered = birthdayEntry.Date;

            Gender genderSelected = newChildGender;

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
                if(sex == "Male")
                {
                    newChildGender = Gender.MALE;

                } else
                {
                    newChildGender = Gender.FEMALE;
                }
                ChildDatabaseAccess childDatabase = new ChildDatabaseAccess();
                childDatabase.InitializeSync();
                Child newChild = new Child(nameEntered, birthdayEntered, newChildGender);
                childDatabase.SaveUserChildSync(newChild);
                childDatabase.CloseSyncConnection();
                ContextDatabaseAccess contextDB = new ContextDatabaseAccess();
                contextDB.InitializeSync();
                Context context = contextDB.GetContextSync();
                context.ChildId = newChild.ID;
                contextDB.SaveContextSync(context);
                contextDB.CloseSyncConnection();
            }

            await Navigation.PopModalAsync();
        }

        private static Gender newChildGender = Gender.UNSPECIFIED;
    }
}