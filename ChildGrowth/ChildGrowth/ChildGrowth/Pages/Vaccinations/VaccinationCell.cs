using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChildGrowth.Pages.Vaccinations
{
    public class VaccinationCell : ViewCell
    {
        public VaccinationCell()
        {
                var VaccinationName = new Label
                {
                    Text = "",
                    TextColor = Color.White,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    FontAttributes = FontAttributes.Bold,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Start,


                };
                VaccinationName.SetBinding(Label.TextProperty, "VaccineName");

            View = new StackLayout
                {
                    
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                    Padding = new Thickness(15, 5, 15, 15),

                    Children = {

                    new StackLayout {
                        Padding = new Thickness (15, 5, 0, 15),
                        Orientation = StackOrientation.Vertical,
                        HorizontalOptions = LayoutOptions.EndAndExpand,
                        Children = { VaccinationName
                        },


                    }
                }
                };
            }
        }
    }

