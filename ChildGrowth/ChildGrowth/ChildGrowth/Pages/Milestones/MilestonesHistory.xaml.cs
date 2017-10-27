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
            var M = (MilestonesInfo)e.AddedItems[0];
            //if (e.AddeItems.Count > 0 && e.AddedItems[0] == ViewModel.Items[0])
            //    e.Cancel = true;

            Navigation.PushAsync(new MilestonesInfoView(M));


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
        public Image Like { get; set; }
        public Image DisLike { get; set; }

        MilestonesInfo M;

        public MilestonesInfoView(MilestonesInfo m)

        {
            this.M = m;

           // Name.Text = m.CategoryName;
           // Description.Text =m.CategoryDescription;
           // firstDesc.Text = "";
            //firstDesc2.Text = "";
            //Photo.Source = ImageSource.FromUri(); //ImageSource.FromFile(ItemsSource[itemIndex].Photo);
                                                                  //card.Photo.Source = ImageSource.FromResource(ItemsSource[itemIndex].Photo);


            RelativeLayout view = new RelativeLayout();

            // box view as background
            // white for now.
            BoxView background = new BoxView
            {
                Color = Color.White,
                Scale = 4,
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
                FontSize = 12,
                InputTransparent = true,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center
            };

            view.Children.Add(firstDesc2,
                Constraint.RelativeToParent((parent) => { return parent.Width - parent.Width + 5; }),
                Constraint.RelativeToParent((parent) => { return parent.Height - 85; }),
                //Constraint.RelativeToParent((parent) => { return parent.Height - 80; }), //MIDDLE
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; }));

            Name.Text = m.CategoryName;
            Description.Text = m.CategoryDescription;
            firstDesc.Text = "";
            firstDesc2.Text = "";
            Photo.Source = ImageSource.FromUri(new Uri("http://runt-of-the-web.com/wordpress/wp-content/uploads/2017/04/vending-machine-1.jpg"));
            this.Content = view;


        }
    }
}

