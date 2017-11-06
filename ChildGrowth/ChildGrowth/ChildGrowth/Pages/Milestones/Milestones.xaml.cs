using Syncfusion.DataSource;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Syncfusion.ListView.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ChildGrowth.Persistence;
using ChildGrowth.Models.Settings;
using ChildGrowth.Pages.Settings;

namespace ChildGrowth.Pages.Milestones
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Milestones : ContentPage
    {
        Child currentChild;
        CardStackView cardStack;
        MainPageViewModel viewModel = new MainPageViewModel();
        bool historyView = false;

        override
        protected void OnAppearing()
        {
            UpdateChild();
        }

        public Milestones()
        {
                initializeMilestones();
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
            }
        }

        void OnSettingsClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }

        private void initializeMilestones(){
            //TODO: Have the Initialize Components View show up.
            this.BindingContext = viewModel;
            this.BackgroundColor = Color.Black;

            RelativeLayout view = new RelativeLayout();

            //Initialize card stack and add in listener functions.   
            cardStack = new CardStackView();
            cardStack.SetBinding(CardStackView.ItemsSourceProperty, "ItemsList");
            cardStack.SwipedLeft += SwipedLeft;
            cardStack.SwipedRight += SwipedRight;

            // Dislike_button is our no button. 
            Button dislike_but = new Button()
            {
                Image = (FileImageSource)ImageSource.FromFile("blue_no.png"),
                Scale = 2,
                BackgroundColor = Color.Transparent,
                BorderColor = Color.Transparent,
                BorderRadius = 0,
                BorderWidth = 0
            };

            // Like button is our yes button
            Button like_but = new Button()
            {
                Image = (FileImageSource)ImageSource.FromFile("blue_yes.png"),
                Scale = 2,
                BackgroundColor = Color.Transparent,
                BorderColor = Color.Transparent,
                BorderRadius = 0,
                BorderWidth = 0
            };

            // Click Events. When Like and dislike is handled.
            dislike_but.Clicked += Dislike_but_Clicked;
            like_but.Clicked += Like_but_Clicked;

            // Add card stack to view model 
            view.Children.Add(cardStack,
                Constraint.Constant(30),
                Constraint.Constant(60),
                Constraint.RelativeToParent((parent) => { return parent.Width - 60; }),
                Constraint.RelativeToParent((parent) => { return parent.Height - 140; }));

            // Add dislike buttons to viewmodel
            view.Children.Add(dislike_but,
                Constraint.RelativeToParent((parent) => { return parent.Width - parent.Width + 75; }),
                Constraint.RelativeToParent((parent) => { return parent.Height - 80; }),
                //Constraint.RelativeToParent((parent) => { return parent.Height - 80; }), //MIDDLE
                Constraint.Constant(75),
                Constraint.Constant(50));

            // Add like buttons to viewmodel
            view.Children.Add(like_but,
                Constraint.RelativeToParent((parent) => { return parent.Width - 135; }),
                Constraint.RelativeToParent((parent) => { return parent.Height - 80; }),
                //Constraint.RelativeToParent((parent) => { return parent.Height - 80; }), //MIDDLE
                Constraint.Constant(75),
                Constraint.Constant(50));


            this.LayoutChanged += (object sender, EventArgs e) =>
            {
                cardStack.CardMoveDistance = (int)(this.Width / 3);
            };

            this.Content = view;
        }
        //  Liked button is clicked.
        private void Like_but_Clicked(object sender, EventArgs e)
        {
            SwipedRight(cardStack.itemIndex);
            cardStack.GetNextCard().Scale = 1;
            if (!cardStack.ShowNextCard())
            {
                Navigation.PushAsync(new NavigationPage(new MilestonesHistory()));
            }

        }

        // Dislike button is clicked
        private void Dislike_but_Clicked(object sender, EventArgs e)
        {
            SwipedLeft(cardStack.itemIndex);
            cardStack.GetNextCard().Scale = 1;
            if (!cardStack.ShowNextCard())
            {
                
                Navigation.PushAsync(new NavigationPage(new MilestonesHistory()));
            };
        }

        public void showHistory()
        {

            MilestonesInfoRepository viewModel = new MilestonesInfoRepository();
            listView = new SfListView();
            listView.ItemSize = 100;
            listView.ItemsSource = viewModel.MilestonesInfo;
            listView.ItemTemplate = new DataTemplate(() => {
                var grid = new Grid();
                var bookName = new Label { FontAttributes = FontAttributes.Bold, BackgroundColor = Color.Teal, FontSize = 21 };
                bookName.SetBinding(Label.TextProperty, new Binding("categoryName"));
                var bookDescription = new Label { BackgroundColor = Color.Teal, FontSize = 15 };
                bookDescription.SetBinding(Label.TextProperty, new Binding("categoryDesc"));

                grid.Children.Add(bookName);
                grid.Children.Add(bookDescription, 1, 0);

                return grid;
            });



            this.Content = listView;
           
        }

        HashSet<int> likedIds = new HashSet<int>();
        HashSet<int> dislikedIds = new HashSet<int>();
        
        // Swiped right function
        void SwipedRight(int index)
        {
            index = (index - 2) < 0 ? -1 * (index - 2) % 4 : (index - 2) % 4;
            int currID = cardStack.ItemsSource[index].ID;
            likedIds.Add(currID);
            cardStack.GetNextCard().Scale = 1;
            cardStack.GetTopCard().Scale = 1;
           
            cardStack.cards[cardStack.topCardIndex].firstDesc.Text = "";
            cardStack.cards[cardStack.topCardIndex].firstDesc2.Text = "";
            cardStack.cards[cardStack.topCardIndex].Scale = 1;
            cardStack.GetNextCard().Scale = 1; 

        }

        // Swiped left function
        void SwipedLeft(int index)
        {
            index = (index - 2) < 0 ? -1 * (index - 2) % 4 : (index - 2) % 4;
            int currID = cardStack.ItemsSource[index].ID;
            dislikedIds.Add(currID);
            cardStack.GetNextCard().Scale = 1;
            cardStack.GetTopCard().Scale = 1;
            
 
            cardStack.cards[cardStack.topCardIndex].firstDesc.Text = "";
            cardStack.cards[cardStack.topCardIndex].firstDesc2.Text = "";
            cardStack.cards[cardStack.topCardIndex].Scale = 1;
            cardStack.GetNextCard().Scale = 1;
            
        }

    }
}
    