using ChildGrowth.Pages.Vaccinations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ChildGrowth.Pages.Settings;
using ChildGrowth.Persistence;
using ChildGrowth.Models.Settings;
using ChildGrowth.Models.Vaccinations;

using Syncfusion.ListView.XForms;

namespace ChildGrowth.Pages.Vaccinations
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vaccinations : ContentPage
    {
        private Child CurrentChild { get; set; }

        public static List<Vaccine> dueVaccines = new List<Vaccine>();

        public static List<Vaccine> takenVaccines = new List<Vaccine>();

        private static int numberItemsTappedHandlersBound = 0;

        SfListView vaccinationList = new SfListView
        {
            RowSpacing = 70
        };

        void OnSettingsClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }

        static double percentprog = 0.2;

        ProgressBar vacProg = new ProgressBar
        {
            Progress = percentprog,
        };


        public Vaccinations()
        {
            //initializeVaccinations();

        }

        private void initializeVaccinations()
        {
            var layout = new StackLayout();

            BackgroundColor = Color.FromRgb(94, 196, 225);

            //Vaccines = GetVaccineHistoryForCurrentChild();

            vaccinationList.ItemsSource = dueVaccines;
            vaccinationList.ItemTemplate = new DataTemplate(typeof(VaccinationCell));
            vaccinationList.BackgroundColor = Color.Transparent;
            //vaccinationList.SeparatorColor = Color.White;

            /*
            vaccinationList.ItemSelected += (sender, e) =>
            {
                ((ListView)sender).SelectedItem = null;
            };
            */


            Vaccine V;

            vaccinationList.ItemTapped += (sender, e) =>
            {
                V = (Vaccine)e.ItemData;
                Navigation.PushAsync(new VaccinationInfoView(V, CurrentChild));

            };
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(0, 10, 0, 10),
                Children = {
                  vacProg,
                  vaccinationList
                }
            };

        }
        async void updateProgBar()
        {
            if(CurrentChild != null)
            {
                await vacProg.ProgressTo(CurrentChild.GetVaccinationCompletionPercentage(), 250, Easing.Linear);
            }
            else
            {
                await vacProg.ProgressTo(0, 250, Easing.Linear);
            }
        }

        override
        protected void OnAppearing()
        {
            Task Load = Task.Run(async () => { await LoadContext(); });
            Load.Wait();
            if (CurrentChild != null)
            {
                this.Title = CurrentChild.Name;
                dueVaccines = CurrentChild.GetListOfDueVaccines();
                takenVaccines = CurrentChild.GetVaccineHistory();
                initializeVaccinations();
                updateProgBar();
            }
            else
            {
                this.Title = "Please Select a Child";
                dueVaccines = new List<Vaccine>();
                takenVaccines = new List<Vaccine>();
                initializeVaccinations();
                updateProgBar();
            }
        }

        private async Task<Boolean> LoadContext()
        {
            Context CurrentContext;
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
                //contextDB.CloseSyncConnection();
            }
            // If context doesn't exist, create it, save it, and populate vaccine/milestones databases.
            if (CurrentContext == null)
            {
                CurrentContext = new Context();
                // Exception probably broke the synchronous connection.
                //contextDB.InitializeSync();
                ContextDatabaseAccess newContextDB = new ContextDatabaseAccess();
                await newContextDB.InitializeAsync();
                newContextDB.SaveFirstContextAsync(CurrentContext);
                //newContextDB.CloseSyncConnection();
                CurrentChild = null;
                Task tVaccine = VaccineTableConstructor.ConstructVaccineTable();
                Task tMilestone = MilestonesTableConstructor.ConstructMilestonesTable();
                await tVaccine;
                await tMilestone;
                return true;
            }
            else
            {
                CurrentChild = CurrentContext.GetSelectedChild(); ;
                return true;
            }
        }


        /*
        public void VaccinationRepository()
        {
            
            Vaccines.Add(new VaccinationTable() { VaccinationID = 1, Name = "Hepatitis B (HepB)", Info = " ", Time = 0 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 2, Name = "Hepatitis B (HepB)", Info = " ", Time = 1 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 3, Name = "Rotavirus (RV)", Info = " ", Time = 2 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 4, Name = "Diphtheria and tetanus toxoids and acellular pertussis (DTaP)", Info = " ", Time = 2 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 5, Name = "Haemophilus influenzae type b (Hib)", Info = " ", Time = 2 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 6, Name = "Pneumococcal conjugate (PCV13)", Info = " ", Time = 2 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 7, Name = "Inactivated poliovirus (IPV:<18 yrs)", Info = " ", Time = 2 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 8, Name = "Rotavirus (RV)", Info = " ", Time = 4 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 9, Name = "Diphtheria and tetanus toxoids and acellular pertussis (DTaP)", Info = " ", Time = 4 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 10, Name = "Haemophilus influenzae type b (Hib)", Info = " ", Time = 4 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 11, Name = "Pneumococcal conjugate (PCV13)", Info = " ", Time = 4 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 12, Name = "Inactivated poliovirus (IPV:<18 yrs)", Info = " ", Time = 4 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 13, Name = "Hepatitis B (HepB)", Info = " ", Time = 6 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 14, Name = "Diphtheria and tetanus toxoids and acellular pertussis (DTaP)", Info = " ", Time = 6 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 15, Name = "Pneumococcal conjugate (PCV13)", Info = " ", Time = 6 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 16, Name = "Inactivated poliovirus (IPV:<18 yrs)", Info = " ", Time = 6 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 17, Name = "Influenza (IIV)", Info = " ", Time = 6 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 18, Name = "Haemophilus influenzae type b (Hib)", Info = " ", Time = 12 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 19, Name = "Pneumococcal conjugate (PCV13)", Info = " ", Time = 12 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 20, Name = "Measles, mumps, rubella (MMR)", Info = " ", Time = 12 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 21, Name = "Varicella (VAR)", Info = " ", Time = 12 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 22, Name = "Hepatitis A (HepA)", Info = " ", Time = 12 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 23, Name = "Diphtheria and tetanus toxoids and acellular pertussis (DTaP)", Info = " ", Time = 15 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 24, Name = "Influenza (IIV)", Info = " ", Time = 18 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 25, Name = "Hepatitis A (HepA) - Second Dose", Info = " ", Time = 24 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 26, Name = "Influenza (IIV)", Info = " ", Time = 30 });
        }
        */
    }
}

public class VaccinationInfoView : ContentPage  
{

    Label VName, isTakenLabel;

    Button isTakenButton;

    int isTaken;

    Vaccine V;

    Child C;
    public VaccinationInfoView(Vaccine v, Child currentChild)

    {
        this.V = v;
        this.C = currentChild;

        BackgroundColor = Color.FromRgb(197, 255, 255);

        VName = new Label
        {

            Text = V.VaccineName,

            TextColor = Color.FromHex("#5069A1"),

            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),

            HorizontalOptions = LayoutOptions.EndAndExpand,

            VerticalOptions = LayoutOptions.Center,

        };

        isTakenButton = new Button
        {

            VerticalOptions = LayoutOptions.Center,

            HorizontalOptions = LayoutOptions.EndAndExpand,

            BorderRadius = 100,

            WidthRequest = 45,

            HeightRequest = 50,

        };

        isTakenLabel = new Label
        {

            TextColor = Color.FromHex("#5069A1"),

            FontAttributes = FontAttributes.Bold,

            VerticalOptions = LayoutOptions.Center,

            HorizontalOptions = LayoutOptions.EndAndExpand,

            FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))

        };

        EventHandler<Syncfusion.ListView.XForms.ItemTappedEventArgs> handler = null;


        isTakenButton.Clicked += (sender, e) =>
        {
            if(currentChild == null)
            {
                return;
            }
            else if (currentChild.HasVaccine(V.ID))
            {

                //update database here
                //not taken
                currentChild.RemoveFromVaccineHistory(V.ID);
 
                isTakenButton.Image = (FileImageSource)ImageSource.FromFile("X.png");
                 
                isTakenButton.BackgroundColor = Color.Transparent;

                isTakenLabel.Text = "Not Taken";

                isTaken = 0;

            }
            else
            {
                currentChild.AddOrUpdateVaccineHistory(V.ID);

                isTakenButton.Image = (FileImageSource)ImageSource.FromFile("right.png");

                isTakenButton.BackgroundColor = Color.Transparent;

                isTakenLabel.Text = "Taken";

                isTaken = 1;



            }

        };



        var VInfo = new Label
        {

            Text = V.Info,

            TextColor = Color.FromHex("#5069A1"),

            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

            HorizontalOptions = LayoutOptions.End

        };




        //parse childs birthday
        //DateTime Vacc_Time = DateTime.ParseExact(c.birthDate, "ddMMyyyy", null).AddMonths(when);


        /*
        var date = new Label
        {

            //Text = "Vacinnation date   :      " + Vacc_Time.Year + " / " + Vacc_Time.Month + " / " + Vacc_Time.Day,

            TextColor = Color.FromHex("#FFA4C1"),

            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

            FontAttributes = FontAttributes.Bold,

            HorizontalOptions = LayoutOptions.Center

        };
        */


        Content = new StackLayout
        {

            Padding = new Thickness(0, 20, 0, 0),

            Orientation = StackOrientation.Vertical,

            HorizontalOptions = LayoutOptions.FillAndExpand,

            Children = {

                    new StackLayout{

                        BackgroundColor = Color.FromHex("#FFA4C1"),

                        Orientation = StackOrientation.Horizontal,

                        HorizontalOptions = LayoutOptions.FillAndExpand,

                        Padding = new Thickness(20,0,20,20),

                        Children={

                             isTakenLabel, isTakenButton, VName

                        }

                    },

                    new StackLayout{

                        Padding = new Thickness(0,0 , 0, 0),

                        Children = {

                            //date

                        }

                    },

                    new ScrollView{



                        Content = new StackLayout{

                            HorizontalOptions = LayoutOptions.End,

                            Padding = new Thickness(10, 5, 10, 10),

                            Spacing = 2,

                            Children = {

                                VInfo

                            }

                        }

                    }

                }

        };

    }



    protected override void OnAppearing()

    {

        //isTaken = 


        if(C == null)
        {
            // Do nothing.
        }
        else if (C.HasVaccine(V.ID)) // Current child has the current vaccine.
        { 

            isTakenButton.Image = (FileImageSource)ImageSource.FromFile("right.png");

            isTakenButton.BackgroundColor = Color.Transparent;

            isTakenLabel.Text = "Taken";



        }
        else 

        {

            isTakenButton.Image = (FileImageSource)ImageSource.FromFile("X.png");

            isTakenButton.BackgroundColor = Color.Transparent;

            isTakenLabel.Text = "Not Taken";

        }

        base.OnAppearing();

    }

}

