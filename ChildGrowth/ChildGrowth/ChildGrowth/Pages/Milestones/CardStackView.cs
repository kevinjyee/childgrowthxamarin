using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace ChildGrowth.Pages.Milestones
{
    public class CardStackView : ContentView
    {
        public class Item
        {
            public string Name { get; set; }
            public Uri Photo { get; set; }
            
            public string Description { get; set; }
            public string firstDesc { get; set; }
            public string firstDesc2 { get; set; }
            public int ID { get; set; }
        }


        // back card scale. how much of the screen should i fill up
        const float BackCardScale = 0.8f;

        // speed of the animations
        const int AnimLength = 300;

        // 180/pi
        const float DegreesToRadians = 57.2957795f; // <-- 180 / pi

        // higher the number less the rotation effect
        const float CardRotationAdjuster = 0.3f;

        // distance a card must be moved to consider to be swiped off
        public int CardMoveDistance { get; set; }


        // default number of cards. (put 2 as defualt) 
        const int NumCards = 2;
        
        // Arrayset
        public CardView[] cards = new CardView[NumCards];

        // the card at the top of the stack
        public int topCardIndex;

        // distance the card has been moved
        float cardDistance = 0;

        // the last items index added to the stack of the cards
        public int itemIndex = 0;
        bool ignoreTouch = false;


        // called when a card is swiped left/right with the card index in the ItemSource
        public Action<int> SwipedRight = null;
        public Action<int> SwipedLeft = null;

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(System.Collections.IList), typeof(CardStackView), null, propertyChanged: OnItemsSourcePropertyChanged);


        public List<Item> ItemsSource
        {
            get
            {
                return (List<Item>)GetValue(ItemsSourceProperty);
            }

            set
            {
                SetValue(ItemsSourceProperty, value);
                itemIndex = 0;
            }
        }

        private static void OnItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((CardStackView)bindable).Setup();
        }

        public CardStackView()
        {

            RelativeLayout view = new RelativeLayout();

            // create a stack of cards
            for (int i = 0; i < NumCards; i++)
            {
                var card = new CardView();
                cards[i] = card;
                card.InputTransparent = true;
                card.IsVisible = false;

                view.Children.Add(card,
                    Constraint.Constant(0),
                    Constraint.Constant(0),
                    Constraint.RelativeToParent((parent) => { return parent.Width; }),
                    Constraint.RelativeToParent((parent) => { return parent.Height; }));
            }

            this.BackgroundColor = Color.Black;
            this.Content = view;

            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnPanUpdated;
            GestureRecognizers.Add(panGesture);

            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += TapGesture_Tapped;
            GestureRecognizers.Add(tapGesture);
        }

        private void TapGesture_Tapped(object sender, EventArgs e)
        {
            // TODO: Is there anything we want to do when tapped? 
            // Stream video. 
            // Kek kill me
        }

        void Setup()
        {
            // set the top card as index 0.
            topCardIndex = 0;

            if(ItemsSource == null)
            {
                return;
            }
            // create a stack of cards
            for (int i = 0; i < Math.Min(NumCards, ItemsSource.Count); i++)
            {
                if (itemIndex >= ItemsSource.Count)
                {
                    break;
                }
                var card = cards[i];
                card.Name.Text = ItemsSource[itemIndex].Name;
                card.Description.Text = ItemsSource[itemIndex].Description;
                card.firstDesc.Text = ItemsSource[itemIndex].firstDesc;
                card.firstDesc2.Text = ItemsSource[itemIndex].firstDesc2;
                card.Photo.Source = ImageSource.FromUri(ItemsSource[itemIndex].Photo); //ImageSource.FromFile(ItemsSource[itemIndex].Photo);
                //card.Photo.Source = ImageSource.FromResource(ItemsSource[itemIndex].Photo);
                card.ID = ItemsSource[itemIndex].ID;
                card.IsVisible = true;
                card.Scale = GetScale(i);
                card.RotateTo(0, 0);
                card.TranslateTo(0, -card.Y, 0);
                ((RelativeLayout)this.Content).LowerChild(card);
                itemIndex++;
            }
        }

        void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    Handle_TouchStart();
                    break;

                case GestureStatus.Running:
                    Handle_Touch((float)e.TotalX);
                    break;

                case GestureStatus.Completed:
                    Handle_TouchEnd();
                    break;
            }
        }

        // to handle when a touch event begins.
        public void Handle_TouchStart()
        {
            cardDistance = 0;
        }

        // to handle te ongoing touch event as the card is moved
        public void Handle_Touch(float diff_x)
        {
            if (ignoreTouch)
            {
                return;
            }

            var topCard = cards[topCardIndex];
            var backCard = cards[PrevCardIndex(topCardIndex)];

            // move the top card
            if (topCard.IsVisible)
            {
                // move the card
                topCard.TranslationX = (diff_x);

                // calculate a angle for the card
                float rotationAngel = (float)(CardRotationAdjuster * Math.Min(diff_x / this.Width, 1.0f));
                topCard.Rotation = rotationAngel * DegreesToRadians;
                if (diff_x < 0)
                {
                    // TODO: should left be differnet from right? Maybe not needed.
                }
                if (diff_x > 0)
                {
                    // TODO: should left be differnet from right? Maybe not needed.
                }

                // keep a record of how far its moved
                cardDistance = diff_x;
            }

            // Kevin being super extra. Pretty neat animation.
            if (backCard.IsVisible)
            {
                backCard.Scale = Math.Min(BackCardScale + Math.Abs((cardDistance / CardMoveDistance) * (1.0f - BackCardScale)), 1.0f);
            }
        }

        // to handle the ongoing touch event as the card is moved
        async public void Handle_TouchEnd()
        {
            ignoreTouch = true;

            var topCard = cards[topCardIndex];



            // if the card was move enough to be considered swiped off
            if (Math.Abs((int)cardDistance) > CardMoveDistance)
            {
                // move off the screen
                await topCard.TranslateTo(cardDistance > 0 ? this.Width : -this.Width, 0, AnimLength / 2, Easing.SpringOut);
                topCard.IsVisible = false;

                if (SwipedRight != null && cardDistance > 0)
                {
                    SwipedRight(itemIndex);
                    
                }
                else if (SwipedLeft != null)
                {
                    SwipedLeft(itemIndex);
                    
                }

                // // show the next card
                ShowNextCard();
            }

            // put the card back in the center
            else
            {
                // move the top card back to the center
                await topCard.TranslateTo((-topCard.X), -topCard.Y, AnimLength, Easing.SpringOut);
                await topCard.RotateTo(0, AnimLength, Easing.SpringOut);

                // scale the back card down
                var prevCard = cards[PrevCardIndex(topCardIndex)];
                await prevCard.ScaleTo(BackCardScale, AnimLength, Easing.SpringOut);
            }

            ignoreTouch = false;
        }

        public Boolean ShowNextCard()
        {
            // show the next card
            if (cards[0].IsVisible == false && cards[1].IsVisible == false)
            {
                Setup();
                return true;
            }

            var topCard = cards[topCardIndex];
            topCardIndex = NextCardIndex(topCardIndex);

            if (itemIndex >= ItemsSource.Count)
            {
                // LOOP for now... initilize graph somehow.
                itemIndex = 0;
                return false;
                
            }

            // if there are more cards to show, show the next card in to place of 
            // the card that was swipped off the screen
            if (itemIndex < ItemsSource.Count)
            {
                // push it to the back z order
                ((RelativeLayout)this.Content).LowerChild(topCard);

                // reset its scale, opacity and rotation
                topCard.Scale = BackCardScale;
                topCard.RotateTo(0, 0);
                topCard.TranslateTo(0, -topCard.Y, 0);

                // set the data
                topCard.Name.Text = ItemsSource[itemIndex].Name;
                topCard.Description.Text = ItemsSource[itemIndex].Description;

                topCard.Photo.Source = ImageSource.FromUri(ItemsSource[itemIndex].Photo);
                //topCard.Photo.Source = ImageSource.FromResource(ItemsSource[itemIndex].Photo);


                topCard.IsVisible = true;
                itemIndex++;
            }
            return true;
        }

        // return the next card index from the top
        int NextCardIndex(int topIndex)
        {
            return topIndex == 0 ? 1 : 0;
        }

        // Gets the next card in the deck as a cardview
        public CardView GetNextCard()
        {
            var backCard = cards[PrevCardIndex(topCardIndex)];
            return backCard;
        }

        // return the prev card index from the top
        int PrevCardIndex(int topIndex)
        {
            return topIndex == 0 ? 1 : 0;
        }

        // helper to get the scale based on the card index position relative to the top card
        float GetScale(int index)
        {
            return (index == topCardIndex) ? 1.0f : BackCardScale;
        }

        public CardView GetTopCard()
        {
            return cards[topCardIndex];
        }
    }
}
