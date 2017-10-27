using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ChildGrowth.Pages.Education
{
    public class EducationInfo : ContentPage
    {
        //    public static List<VaccinationTable> Vaccines = new List<VaccinationTable>();

        //    ListView vaccinationList = new ListView
        //    {
        //        RowHeight = 40
        //    };

        //    static double percentprog = 0.2;

        //    ProgressBar vacProg = new ProgressBar
        //    {
        //        Progress = percentprog,
        //    };


        //    public Vaccinations()
        //    {
        //        var layout = new StackLayout();

        //        BackgroundColor = Color.FromRgb(94, 196, 225);

        //        VaccinationRepository();





        //        vaccinationList.ItemsSource = Vaccines;
        //        vaccinationList.ItemTemplate = new DataTemplate(typeof(VaccinationCell));
        //        vaccinationList.BackgroundColor = Color.Transparent;
        //        vaccinationList.SeparatorColor = Color.White;
        //        vaccinationList.ItemSelected += (sender, e) => {
        //            ((ListView)sender).SelectedItem = null;
        //        };

        //        vaccinationList.ItemSelected += (sender, e) => {

        //            ((ListView)sender).SelectedItem = null;

        //        };

        //        vaccinationList.ItemTapped += (Sender, Event) =>
        //        {




        //            var V = (VaccinationTable)Event.Item;

        //            Navigation.PushAsync(new VaccinationInfoView(V));



        //        };

        //        Content = new StackLayout
        //        {
        //            VerticalOptions = LayoutOptions.FillAndExpand,
        //            Padding = new Thickness(0, 10, 0, 10),
        //            Children = {
        //              vacProg,
        //              vaccinationList
        //            }
        //        };


        //    }
        //    async void updateProgBar()
        //    {
        //        await vacProg.ProgressTo(percentprog, 250, Easing.Linear);
        //    }


        //    protected override void OnAppearing()
        //    {

        //    }

        //    public void VaccinationRepository()
        //    {
        //        Vaccines.Add(new VaccinationTable() { VaccinationID = 1, Name = "Shot1", Info = "Enlarge Penis", Time = 1 });
        //        Vaccines.Add(new VaccinationTable() { VaccinationID = 2, Name = "Shot2", Info = "Enlarge Big Penis", Time = 2 });
        //        Vaccines.Add(new VaccinationTable() { VaccinationID = 3, Name = "Shot3", Info = "Enlarge Bigger Penis", Time = 2 });
        //        Vaccines.Add(new VaccinationTable() { VaccinationID = 4, Name = "Shot4", Info = "Enlarge Bigger Bigger Penis", Time = 2 });
        //        Vaccines.Add(new VaccinationTable() { VaccinationID = 3, Name = "Shot5", Info = "Enlarge Bigger Penis", Time = 2 });
        //    }
        //}
    }
}
