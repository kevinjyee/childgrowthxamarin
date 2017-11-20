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
using ChildGrowth.Pages.Menu;
using ChildGrowth.Models.Vaccinations;

namespace ChildGrowth.Pages.Vaccinations
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vaccinations : ContentPage
    {
        private MenuMasterDetailPage MasterPage { get; set; }

        private Child _currentChild;

        public Child CurrentChild
        {
            get
            {
                return _currentChild;
            }
            set
            {
                if (_currentChild?.ID != value?.ID)
                {
                    _currentChild = value;
                    OnPropertyChanged("CurrentChild");
                    UpdateTitle();
                    UpdateVaccineList();
                    UpdateProgressBar();
                }
            }
        }

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

        public static List<Vaccine> Vaccines = new List<Vaccine>();

        public static List<Vaccine> HistoricalVaccines = new List<Vaccine>();

        private static int numberItemsTappedHandlersBound = 0;

        private static int numberHistoricalItemsTappedHandlersBound = 0;

        Label vaccinationListHeader = new Label
        {
            Text = "Vaccinations Pending",
            FontSize = 20,
            TextColor = Color.WhiteSmoke,
            BackgroundColor = Color.FromRgb(94 - 50, 196 - 50, 225 - 50)
        };

        ListView vaccinationList = new ListView
        {
            RowHeight = 70
        };

        Label vaccinationHistoryListHeader = new Label
        {
            Text = "Vaccinations Received",
            FontSize = 20,
            TextColor = Color.WhiteSmoke,
            BackgroundColor = Color.FromRgb(94 - 50, 196 - 50, 225 - 50)
        };

        ListView vaccinationHistoryList = new ListView
        {
            RowHeight = 70
        };

        void OnSettingsClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage(MasterPage));
        }

        static double percentprog = 0.2;

        ProgressBar vacProg = new CustomProgressBar
        {
            Progress = percentprog,
            Scale = 2f
            //Color = Color.FromRgb(94 - 50, 196 - 50, 225 - 50)
        };

        Label progBarTitle = new Label
        {
            Text = "Vaccination Progress",
            FontSize = 20,
            TextColor = Color.WhiteSmoke,
            BackgroundColor = Color.FromRgb(94 - 50, 196 - 50, 225 - 50)
        };

        public Vaccinations()
        {
            //initializeVaccinations();

        }

        public Vaccinations(MenuMasterDetailPage Page)
        {
            //InitializeComponent();
            MasterPage = Page;
        }

        private void initializeVaccinations()
        {
            var layout = new StackLayout();

            BackgroundColor = Color.FromRgb(94, 196, 225);

            //Vaccines = GetVaccineHistoryForCurrentChild();

            vaccinationList.ItemsSource = Vaccines;
            vaccinationList.ItemTemplate = new DataTemplate(typeof(VaccinationCell));
            vaccinationList.BackgroundColor = Color.Transparent;
            vaccinationList.SeparatorColor = Color.White;

            vaccinationHistoryList.ItemsSource = HistoricalVaccines;
            vaccinationHistoryList.ItemTemplate = new DataTemplate(typeof(VaccinationCell));
            vaccinationHistoryList.BackgroundColor = Color.Transparent;
            vaccinationHistoryList.SeparatorColor = Color.White;

            /*
            vaccinationList.ItemSelected += (sender, e) =>
            {
                ((ListView)sender).SelectedItem = null;
            };
            */

            EventHandler<ItemTappedEventArgs> itemTapHandler = null;
            itemTapHandler = (Sender, Event) =>
            {
                vaccinationList.ItemTapped -= itemTapHandler;
                numberItemsTappedHandlersBound--;

                var V = (Vaccine)Event.Item;

                Navigation.PushAsync(new VaccinationInfoView(V, CurrentChild));
            };
            // pot race cond.
            if(numberItemsTappedHandlersBound <= 0)
            {
                vaccinationList.ItemTapped += itemTapHandler;
                numberItemsTappedHandlersBound = 1;
            }

            EventHandler<ItemTappedEventArgs> historicalItemTapHandler = null;
            historicalItemTapHandler = (Sender, Event) =>
            {
                vaccinationHistoryList.ItemTapped -= historicalItemTapHandler;
                numberHistoricalItemsTappedHandlersBound--;

                var V_hist = (Vaccine)Event.Item;

                Navigation.PushAsync(new VaccinationInfoView(V_hist, CurrentChild));
            };
            // pot race cond.
            if (numberHistoricalItemsTappedHandlersBound <= 0)
            {
                vaccinationHistoryList.ItemTapped += historicalItemTapHandler;
                numberHistoricalItemsTappedHandlersBound = 1;
            }

            // Add new label, new list

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(0, 10, 0, 10),
                Children = {
                  progBarTitle,
                  vacProg,
                  vaccinationListHeader,
                  vaccinationList,
                  vaccinationHistoryListHeader,
                  vaccinationHistoryList
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
            if(CurrentContext == null)
            {

            }
        }

        override
        protected void OnAppearing()
        {
            Task Load = Task.Run(async () => { await LoadContext(); });
            Load.Wait();
            UpdateTitle();
            UpdateVaccineList();
            UpdateProgressBar();
            /*
            if (CurrentContext.CurrentLanguage == Language.ENGLISH)
            {
                SetEnglish();
            }
            else
            {
                SetSpanish();
            }
            if (CurrentChild != null)
            {
                this.Title = CurrentChild.Name;
                Vaccines = CurrentChild.GetListOfDueVaccines();
                initializeVaccinations();
                updateProgBar();
            }
            else
            {
                if (CurrentContext.CurrentLanguage == Language.ENGLISH)
                {
                    this.Title = "Please Select a Child";
                } 
                else
                {
                    this.Title = "Porfavor Seleccione un niño";
                }
                Vaccines = new List<Vaccine>();
                initializeVaccinations();
                updateProgBar();
            }
            */
        }

        void UpdateTitle()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (CurrentContext == null)
                {
                    CurrentContext = Context.LoadCurrentContext();
                }
                if (CurrentChild != null)
                {
                    this.Title = CurrentChild.Name;

                }
                else
                {
                    if (CurrentContext.CurrentLanguage == Language.ENGLISH)
                    {
                        this.Title = "Please Select a Child";
                    }
                    else
                    {
                        this.Title = "Porfavor Seleccione un Niño";
                    }
                }
            });
        }

        void SetEnglish()
        {
            progBarTitle.Text = "Vaccination Progress";
            vaccinationListHeader.Text = "Vaccinations Pending";
            vaccinationHistoryListHeader.Text = "Vaccinations Received";
        }

        void SetSpanish()
        {
            progBarTitle.Text = "Progreso de las Vacunas";
            vaccinationListHeader.Text = "Vacunas Pendientes";
            vaccinationHistoryListHeader.Text = "Vacunas Recibidas";
        }

        void UpdateVaccineList()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (CurrentChild != null)
                {
                    Vaccines = CurrentChild.GetListOfDueVaccines();
                    HistoricalVaccines = CurrentChild.GetVaccineHistory();
                    initializeVaccinations();
                }
                else
                {
                    Vaccines = new List<Vaccine>();
                    HistoricalVaccines = new List<Vaccine>();
                    initializeVaccinations();
                }
            });
        }

        void UpdateProgressBar()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                updateProgBar();
            });
        }

        private async Task<Boolean> LoadContext()
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
    }
}

public class CustomProgressBar : ProgressBar
{
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

        EventHandler<ItemTappedEventArgs> handler = null;


        isTakenButton.Clicked += (sender, e) =>
        {
            if (currentChild == null)
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


        if (C == null)
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

