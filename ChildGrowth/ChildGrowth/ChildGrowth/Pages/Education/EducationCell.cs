using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChildGrowth.Pages.Education
{
    
    public class EducationCell : ViewCell
    {
        public EducationCell()
        {
            var EducationName = new Label
            {
                Text = "",
                TextColor = Color.Black,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
            };
            EducationName.SetBinding(Label.TextProperty, "Title");

            View = new StackLayout
            {

                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(15, 5, 15, 15),

                Children = {

                    new StackLayout {
                        Padding = new Thickness (15, 5, 0, 15),
                        Orientation = StackOrientation.Vertical,
                        HorizontalOptions = LayoutOptions.StartAndExpand,
                        Children = { EducationName
                        },
                    }
                }
            };
        }
    }
}

