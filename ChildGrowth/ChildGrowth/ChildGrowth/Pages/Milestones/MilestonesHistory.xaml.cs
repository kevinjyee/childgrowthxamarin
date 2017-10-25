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
    public partial class MilestonesHistory : ContentPage
    {
        public MilestonesHistory()
        {
            InitializeComponent();

            listView.SelectionChanging += ListView_SelectionChanging;
        }

        

        private void ListView_SelectionChanging(object sender, ItemSelectionChangingEventArgs e)
        {
            var M = (MilestonesInfo) e.AddedItems[0];
            //if (e.AddeItems.Count > 0 && e.AddedItems[0] == ViewModel.Items[0])
            //    e.Cancel = true;

            Navigation.PushAsync(new MilestonesInfoView(M));
        }
    }


    public class MilestonesInfoView : ContentPage

    {

        Label MName, isTakenLabel;

        Button isTakenButton;

        int isTaken;

        MilestonesInfo M;

        public MilestonesInfoView(MilestonesInfo m)

        {
            this.M = m;


            BackgroundColor = Color.FromRgb(197, 255, 255);

            MName = new Label
            {

                Text = M.CategoryName,

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

                Text = M.CategoryDescription,

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

                             isTakenLabel, isTakenButton, MName

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
}