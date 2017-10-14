using Syncfusion.DataSource;
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
    public partial class Milestones : ContentPage
    {
        CardStackView cardStack;
        MainPageViewModel viewModel = new MainPageViewModel();

        public Milestones()
        {
            InitializeComponent();


                this.BindingContext = viewModel;
                this.BackgroundColor = Color.Black;

                RelativeLayout view = new RelativeLayout();

                cardStack = new CardStackView();
                cardStack.SetBinding(CardStackView.ItemsSourceProperty, "ItemsList");
                cardStack.SwipedLeft += SwipedLeft;
                cardStack.SwipedRight += SwipedRight;

                view.Children.Add(cardStack,
                    Constraint.Constant(30),
                    Constraint.Constant(60),
                    Constraint.RelativeToParent((parent) => {
                        return parent.Width - 60;
                    }),
                    Constraint.RelativeToParent((parent) => {
                        return parent.Height - 140;
                    })
                );

                this.LayoutChanged += (object sender, EventArgs e) =>
                {
                    cardStack.CardMoveDistance = (int)(this.Width * 0.40f);
                };

                this.Content = view;
            }

            void SwipedLeft(int index)
            {
                // card swiped to the left
            }

            void SwipedRight(int index)
            {
                // card swiped to the right
            }
           
            
        }
    }
