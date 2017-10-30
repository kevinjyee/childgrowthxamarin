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
            RowHeight = 40
        };
        public Vaccinations(Child C){
            currentChild = C;
            this.Title = currentChild.Name;
            initializeVaccinations();
        }

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

            vaccinationList.ItemTapped += (Sender, Event) => {


            };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(0, 10, 0, 10),
                Children = {
                  new ProgressBar
            {
                Progress = .2,
            },
            vaccinationList
                }
            };

        }

        protected override void OnAppearing()
        {
           
        }

        public void VaccinationRepository()
        {
            Vaccines.Add(new VaccinationTable() { VaccinationID = 1, Name = "Shot1", Info = "Enlarge Penis", Time = new DateTime(2017, 12, 1) });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 2, Name = "Shot2", Info = "Enlarge Brain", Time = new DateTime(2017, 12, 2) });
        }
    }
}