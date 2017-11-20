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
using XLabs.Forms.Controls;
using XLabs.Enums;
using static ChildGrowth.Pages.Milestones.CardStackView;

namespace ChildGrowth.Pages.Milestones
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Milestones : ContentPage
    {
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
                    //_currentChild = value;
                    //OnPropertyChanged("CurrentChild");
                    //UpdateTitle();
                    //initializeMilestones();
                    //UpdateMilestones();
                }
            }
        }
        Context CurrentContext;
        CardStackView cardStack;
        MainPageViewModel viewModel;
        bool historyView = false;
        private int cIdx = 0;
        override
        protected void OnAppearing()
        {
            Task Load = Task.Run(async () => { await LoadContext(); });
            Load.Wait();
            if (CurrentChild != null)
            {
                this.Title = CurrentChild.Name;
                
            }
            else
            {
                this.Title = "Please Select a Child";
            }
            viewModel = new MainPageViewModel();
            //UpdateMilestones();
            //UpdateTitle();
            initializeMilestones();
        }

        public Milestones()
        {
            //OnAppearing();
            //viewModel = new MainPageViewModel();
            //initializeMilestones();

        }

        void UpdateTitle()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (CurrentChild != null)
                {
                    this.Title = CurrentChild.Name;
                }
                else
                {
                    this.Title = "Please Select a Child";
                }
            });
        }

        void UpdateMilestones()
        {
            try
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    { 
                         initializeMilestones();
                    }
                    catch (ObjectDisposedException e)
                    {
                        // TODO: ...
                    }
                });
            }
            catch(ObjectDisposedException e)
            {
                // TODO: ...
            }
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
                CurrentChild = CurrentContext.GetSelectedChild();
                return true;
            }
        }

        void OnSettingsClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }

        private void initializeMilestones()
        {
            //TODO: Have the Initialize Components View show up.
            this.BindingContext = viewModel;
            this.BackgroundColor = Color.Black;

            RelativeLayout view = new RelativeLayout();

            //Initialize card stack and add in listener functions.   
            cardStack = new CardStackView();
            cardStack.SetBinding(CardStackView.ItemsSourceProperty, "ItemsList");
            cardStack.SwipedLeft += SwipedLeft;
            cardStack.SwipedRight += SwipedRight;

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
                Orientation = ImageOrientation.ImageToRight,
                Source = "yes_blue_big"
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

                Constraint.RelativeToParent((parent) => { return parent.Width - parent.Width + 45; }),
                Constraint.RelativeToParent((parent) => { return parent.Height - 80; }),
                //Constraint.RelativeToParent((parent) => { return parent.Height - 80; }), //MIDDLE
                Constraint.Constant(135),
                Constraint.Constant(50));

            // Add like buttons to viewmodel
            view.Children.Add(like_but,
                Constraint.RelativeToParent((parent) => { return parent.Width - 175; }),
                Constraint.RelativeToParent((parent) => { return parent.Height - 80; }),
                //Constraint.RelativeToParent((parent) => { return parent.Height - 80; }), //MIDDLE
                Constraint.Constant(135),
                Constraint.Constant(50));


            this.LayoutChanged += (object sender, EventArgs e) =>
            {
                cardStack.CardMoveDistance = (int)(this.Width / 3);
            };

            try
            {
                this.Content = view;
            }
            catch(Exception e)
            {
                // Do nothing. TODO: Figure out if this is critically wrong.
            }
        }
        //  Liked button is clicked.
        private void Like_but_Clicked(object sender, EventArgs e)
        {
            SwipedRight(cardStack.itemIndex);
            cardStack.GetNextCard().Scale = 1;
            if (!cardStack.ShowNextCard())
            {
                cIdx = 0;
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
                cIdx = 0; 
                Navigation.PushAsync(new NavigationPage(new MilestonesHistory()));
            };
        }

        HashSet<int> likedIds = new HashSet<int>();
        HashSet<int> dislikedIds = new HashSet<int>();

        // Swiped right function
        void SwipedRight(int index)
        {
            if(cardStack == null || cardStack.ItemsSource == null)
            {
                return;
            }
            if (index > 1)
            {
                index = (index - 2) < 0 ? -1 * (index - 2) % 169 : (index - 2) % 169;
            }
            if(cardStack.ItemsSource.Count <= index)
            {
                return;
            }
            int currID = cardStack.ItemsSource[index].ID;
            likedIds.Add(currID);
            if(currID > 0)
            {
                
                CurrentChild.AddOrUpdateMilestoneHistory(currID, Models.Milestones.BinaryAnswer.YES);
            }
            //Item toRemove = cardStack.ItemsSource.Find(p => p.ID == currID);
            //cardStack.ItemsSource.Remove(toRemove);

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
            if (cardStack == null || cardStack.ItemsSource == null)
            {
                return;
            }
            if (index > 1)
            {
                index = (index - 2) < 0 ? -1 * (index - 2) % 169 : (index - 2) % 169;
            }
            if (cardStack.ItemsSource.Count <= index)
            {
                return;
            }
            int currID = cardStack.ItemsSource[index].ID;
            dislikedIds.Add(currID);
            if(currID > 0)
            {
                CurrentChild.AddOrUpdateMilestoneHistory(currID, Models.Milestones.BinaryAnswer.NO);
            }
           // Item toRemove = cardStack.ItemsSource.Find(p => p.ID == currID);
           // cardStack.ItemsSource.Remove(toRemove);

            cardStack.GetNextCard().Scale = 1;
            cardStack.GetTopCard().Scale = 1;


            cardStack.cards[cardStack.topCardIndex].firstDesc.Text = "";
            cardStack.cards[cardStack.topCardIndex].firstDesc2.Text = "";
            cardStack.cards[cardStack.topCardIndex].Scale = 1;
            cardStack.GetNextCard().Scale = 1;

        }

    }
}
