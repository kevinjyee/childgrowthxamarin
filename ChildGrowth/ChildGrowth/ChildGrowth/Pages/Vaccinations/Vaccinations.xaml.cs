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

namespace ChildGrowth.Pages.Vaccinations
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vaccinations : ContentPage
    {
        private Child currentChild { get; set; }

        public static List<VaccinationTable> Vaccines = new List<VaccinationTable>();

        ListView vaccinationList = new ListView
        {
            RowHeight = 40
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
            initializeVaccinations();
        }

        private void initializeVaccinations()
        {
            var layout = new StackLayout();

            BackgroundColor = Color.FromRgb(94, 196, 225);

            VaccinationRepository();

            vaccinationList.ItemsSource = Vaccines;
            vaccinationList.ItemTemplate = new DataTemplate(typeof(VaccinationCell));
            vaccinationList.BackgroundColor = Color.Transparent;
            vaccinationList.SeparatorColor = Color.White;
            vaccinationList.ItemSelected += (sender, e) =>
            {
                ((ListView)sender).SelectedItem = null;
            };

            vaccinationList.ItemSelected += (sender, e) =>
            {

                ((ListView)sender).SelectedItem = null;

            };

            vaccinationList.ItemTapped += (Sender, Event) =>
            {

                var V = (VaccinationTable)Event.Item;

                Navigation.PushAsync(new VaccinationInfoView(V, currentChild));
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
            await vacProg.ProgressTo(percentprog, 250, Easing.Linear);
        }

        override
        protected void OnAppearing()
        {
            UpdateChild();
        }

        async void UpdateChild()
        {
            ContextDatabaseAccess database = new ContextDatabaseAccess();
            await database.InitializeAsync();
            Context context = database.GetContextAsync().Result;
            if (context == null)
            {
                this.Title = "Select Child";
            }
            else
            {
                this.Title = context.GetSelectedChild().Result.Name;
                currentChild = context.GetSelectedChild().Result;
            }
        }


        public void VaccinationRepository()
        {
            Vaccines.Add(new VaccinationTable() { VaccinationID = 1, Name = "Shot1", Info = "Enlarge CategoryDescription", Time = 1 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 2, Name = "Shot2", Info = "Enlarge Big CategoryDescription", Time = 2 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 3, Name = "Shot3", Info = "Enlarge Bigger CategoryDescription", Time = 2 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 4, Name = "Shot4", Info = "Enlarge Bigger Bigger CategoryDescription", Time = 2 });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 3, Name = "Shot5", Info = "Enlarge Bigger CategoryDescription", Time = 2 });
        }
    }
}

public class VaccinationInfoView : ContentPage


{

    Label VName, isTakenLabel;

    Button isTakenButton;

    int isTaken;

    VaccinationTable V;

    Child C;
    public VaccinationInfoView(VaccinationTable v, Child currentChild)

    {
        this.V = v;
        this.C = currentChild;

        BackgroundColor = Color.FromRgb(197, 255, 255);

        VName = new Label
        {



            Text = V.Name,

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





        isTakenButton.Clicked += (sender, e) =>
        {

            if (isTaken == 1)
            {

                //update database here


                //       isTakenButton.Image = (FileImageSource)ImageSource.FromFile("X.png");

                isTakenButton.BackgroundColor = Color.Transparent;

                isTakenLabel.Text = "Not Taken";

                isTaken = 0;

            }
            else if (isTaken == 0)
            {

                //     isTakenButton.Image = (FileImageSource)ImageSource.FromFile("right.png");

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



        if (isTaken == 1)
        {

            //  isTakenButton.Image = (FileImageSource)ImageSource.FromFile("right.png");

            isTakenButton.BackgroundColor = Color.Transparent;

            isTakenLabel.Text = "Taken";



        }
        else if (isTaken == 0)
        {

            // isTakenButton.Image = (FileImageSource)ImageSource.FromFile("X.png");

            isTakenButton.BackgroundColor = Color.Transparent;

            isTakenLabel.Text = "Not Taken";

        }

        base.OnAppearing();

    }

}

