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

        public List<VaccinationTable> Vaccines = new List<VaccinationTable>();

        ListView vaccinationList = new ListView
        {
            RowHeight = 40
        };

        public Vaccinations()
        {
            BackgroundColor = Color.FromRgb(94, 196, 225);

            VaccinationRepository();

            vaccinationList.ItemsSource = Vaccines;
            //vaccinationList.ItemTemplate = new DataTemplate(typeof(EveryVaccinationCell));
            vaccinationList.BackgroundColor = Color.Transparent;
            vaccinationList.SeparatorColor = Color.White;
            //vaccinationList.ItemSelected += (sender, e) => {
              //  ((ListView)sender).SelectedItem = null;
            //};
        }

        public void VaccinationRepository()
        {
            Vaccines.Add(new VaccinationTable() { VaccinationID = 1, Name = "Shot1", Info = "Enlarge Penis", Time = new DateTime(2017, 12, 1) });
            Vaccines.Add(new VaccinationTable() { VaccinationID = 2, Name = "Shot2", Info = "Enlarge Brain", Time = new DateTime(2017, 12, 2) });

        }
    }
}