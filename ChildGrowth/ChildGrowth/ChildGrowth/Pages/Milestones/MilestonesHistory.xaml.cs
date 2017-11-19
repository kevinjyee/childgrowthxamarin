using ChildGrowth.Models.Settings;
using ChildGrowth.Persistence;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Enums;
using XLabs.Forms.Controls;

namespace ChildGrowth.Pages.Milestones
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MilestonesHistory : ContentPage
    {
        Child CurrentChild;

        public MilestonesHistory(Child c)
        {
            InitializeComponent();
            CurrentChild = c;
            listView.SelectionChanging += ListView_SelectionChanging;
        }



        private void ListView_SelectionChanging(object sender, ItemSelectionChangingEventArgs e)
        {
            var M = (MilestonesInfo)e.AddedItems[0];
            //if (e.AddeItems.Count > 0 && e.AddedItems[0] == ViewModel.Items[0])
            //    e.Cancel = true;

            Navigation.PushAsync(new MilestonesInfoView(M,CurrentChild));
        }
    }


    public class MilestonesInfoView : ContentPage

    {

        public Label Name { get; set; }
        public Image Photo { get; set; }

        public Label Location { get; set; }
        public Label Description { get; set; }
        public Label firstDesc { get; set; }
        public Label firstDesc2 { get; set; }
        public int ID { get; set; }
        public ImageButton Like { get; set; }
        public ImageButton DisLike { get; set; }

        MilestonesInfo M;
        Child CurrentChild;

        public MilestonesInfoView(MilestonesInfo m, Child c)

        {
            this.M = m;
            this.CurrentChild = c;
            this.Title = c.Name;

            
            RelativeLayout view = new RelativeLayout();

            // box view as background
            // white for now.
            BoxView background = new BoxView
            {
                Color = Color.White,
                Scale = 3,
                InputTransparent = true
            };
            // put it in my stack
            view.Children.Add(background,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; }));

            // backgroud of background (gray) 
            BoxView boxView1 = new BoxView
            {
                Color = Color.FromRgb(245, 245, 245),
                InputTransparent = true
            };
            // put in stack
            view.Children.Add(boxView1,
                Constraint.Constant(0),
                Constraint.Constant(-30),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; }));

            // item images
            Photo = new Image()
            {
                InputTransparent = true,
                Aspect = Aspect.Fill,
                Scale = 0.95
            };
            // put in stack
            view.Children.Add(Photo,
                Constraint.RelativeToParent((parent) => { double w = parent.Width * 1; return ((parent.Width - w) / 2); }),
                Constraint.Constant(10),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return (parent.Height * 0.75); }));



            // item ttitle 

            Name = new Label()
            {
                TextColor = Color.Black,
                FontSize = 22, //MainPage.screenHeight / 36.8,
                InputTransparent = true,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center
            };

            view.Children.Add(Name,
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => { return parent.Height - parent.Height - 30; }),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.Constant(65));


            // item description 
            Description = new Label()
            {
                TextColor = Color.Black,
                FontSize = 20, //MainPage.screenHeight / 40.8, //Font size 18 40.8
                InputTransparent = true
            };

            view.Children.Add(Description,
                Constraint.RelativeToParent((parent) => { return parent.Width - parent.Width + 5; }),
                Constraint.RelativeToParent((parent) => { return parent.Height - 80; }),
                //Constraint.RelativeToParent((parent) => { return parent.Height - 80; }), //MIDDLE
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.Constant(68));


            firstDesc = new Label()
            {
                TextColor = Color.Black,
                FontSize = 20, //MainPage.screenHeight / 36.8, //Font size 20
                InputTransparent = true
            };

            view.Children.Add(firstDesc,
                Constraint.RelativeToParent((parent) => { return parent.Width - parent.Width + 5; }),
                Constraint.RelativeToParent((parent) => { return parent.Height - parent.Height + 10; }),
                //Constraint.RelativeToParent((parent) => { return parent.Height - 80; }), //MIDDLE
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.Constant(500));


            firstDesc2 = new Label()
            {
                TextColor = Color.DimGray,
                FontSize = 20,
                InputTransparent = true,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center
            };

            view.Children.Add(firstDesc2,
                Constraint.RelativeToParent((parent) => { return parent.Width - parent.Width + 5; }),
                Constraint.RelativeToParent((parent) => { return parent.Height - 115; }),
                //Constraint.RelativeToParent((parent) => { return parent.Height - 80; }), //MIDDLE
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; }));


            //Dislike_button is our no button. 
            var dislike_but = new ImageButton()
            {
                HeightRequest = 90,
                WidthRequest = 200,
                ImageHeightRequest = 90,
                ImageWidthRequest = 200,
                BackgroundColor = Color.Transparent,
                Orientation = ImageOrientation.ImageToLeft,
                Source = "no_blue_big"
            };

            //Like button is our yes button
            var like_but = new ImageButton()
            {
                HeightRequest = 90,
                WidthRequest = 200,
                ImageHeightRequest = 90,
                ImageWidthRequest = 200,
                BackgroundColor = Color.Transparent,
                Orientation = XLabs.Enums.ImageOrientation.ImageToRight,
                Source = "yes_blue_big"
            };

            // Click Events. When Like and dislike is handled.
           dislike_but.Clicked += Dislike_but_Clicked;
            like_but.Clicked += Like_but_Clicked;

       

            // Add dislike buttons to viewmodel
            view.Children.Add(dislike_but,

                Constraint.RelativeToParent((parent) => { return parent.Width - parent.Width + 35; }),
                Constraint.RelativeToParent((parent) => { return parent.Height - 120; }),
                //Constraint.RelativeToParent((parent) => { return parent.Height - 80; }), //MIDDLE
                Constraint.Constant(135),
                Constraint.Constant(50));

            // Add like buttons to viewmodel
            view.Children.Add(like_but,
                Constraint.RelativeToParent((parent) => { return parent.Width - 155; }),
                Constraint.RelativeToParent((parent) => { return parent.Height - 120; }),
                //Constraint.RelativeToParent((parent) => { return parent.Height - 80; }), //MIDDLE
                Constraint.Constant(135),
                Constraint.Constant(50));

            Name.Text = m.CategoryName;
            Description.Text = m.CategoryDescription;
            firstDesc.Text = "";
            
            if(m.Answer == Models.Milestones.BinaryAnswer.YES)
            {
                firstDesc2.Text = "Completed";
                firstDesc2.TextColor = Color.SpringGreen;
            }
            else
            {
                firstDesc2.Text = "Not Completed";
                firstDesc2.TextColor = Color.Red;
                firstDesc2.FontSize = 22;
            }

            Photo.Source = ImageSource.FromUri(new Uri(m.ImageURL));
            this.Content = view;

        }

        private void Like_but_Clicked(object sender, EventArgs e)
        {
            CurrentChild.AddOrUpdateMilestoneHistory(M.ID, Models.Milestones.BinaryAnswer.YES);
            firstDesc2.Text = "Completed";
            firstDesc2.TextColor = Color.SpringGreen;
        }

        // Dislike button is clicked
        private void Dislike_but_Clicked(object sender, EventArgs e)
        {
            CurrentChild.AddOrUpdateMilestoneHistory(M.ID, Models.Milestones.BinaryAnswer.NO);
            firstDesc2.Text = "Not Completed";
            firstDesc2.TextColor = Color.Red;
            firstDesc2.FontSize = 22;
        }
    }
}