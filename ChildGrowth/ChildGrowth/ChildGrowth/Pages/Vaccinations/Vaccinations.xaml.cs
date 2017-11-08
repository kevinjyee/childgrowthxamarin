using ChildGrowth.Pages.Vaccinations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChildGrowth.Pages.Vaccinations
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vaccinations : ContentPage
    {
        private Child currentChild { get; set; }
        
        public static List<VaccinationTable> Vaccines = new List<VaccinationTable>();

        ListView vaccinationList = new ListView
        {
            RowHeight = 70
        };
        public Vaccinations(Child C){
            currentChild = C;
            this.Title = currentChild.Name;
            initializeVaccinations();
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

        private void initializeVaccinations(){
            var layout = new StackLayout();

            BackgroundColor = Color.FromRgb(94, 196, 225);

            VaccinationRepository();

            vaccinationList.ItemsSource = Vaccines;
            vaccinationList.ItemTemplate = new DataTemplate(typeof(VaccinationCell));
            vaccinationList.BackgroundColor = Color.Transparent;
            vaccinationList.SeparatorColor = Color.White;
            vaccinationList.ItemSelected += (sender, e) => {
                ((ListView)sender).SelectedItem = null;
            };

            vaccinationList.ItemSelected += (sender, e) => {

                ((ListView)sender).SelectedItem = null;

            };

            vaccinationList.ItemTapped += (Sender, Event) =>
            {

                var V = (VaccinationTable)Event.Item;

                Navigation.PushAsync(new VaccinationInfoView(V,currentChild));
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
        async void  updateProgBar()
        {
            await vacProg.ProgressTo(percentprog, 250, Easing.Linear);
        }
        

        protected override void OnAppearing()
        {
           
        }

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





        isTakenButton.Clicked += (sender, e) => {

            if (isTaken == 1)
            {

                //update database here
                //not taken
                //currentChild._vaccineHistory.UpdateOrInsertToVaccineHistory(v.VaccinationID);
 
                isTakenButton.Image = (FileImageSource)ImageSource.FromFile("X.png");

                isTakenButton.BackgroundColor = Color.Transparent;

                isTakenLabel.Text = "Not Taken";

                isTaken = 0;

            }
            else if (isTaken == 0)
            {

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



        if (isTaken == 1)
        {

            isTakenButton.Image = (FileImageSource)ImageSource.FromFile("right.png");

            isTakenButton.BackgroundColor = Color.Transparent;

            isTakenLabel.Text = "Taken";



        }
        else if (isTaken == 0)
        {

            isTakenButton.Image = (FileImageSource)ImageSource.FromFile("X.png");

            isTakenButton.BackgroundColor = Color.Transparent;

            isTakenLabel.Text = "Not Taken";

        }

        base.OnAppearing();

    }

}

