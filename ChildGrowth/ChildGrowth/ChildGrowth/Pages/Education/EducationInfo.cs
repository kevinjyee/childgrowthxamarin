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
        //        Vaccines.Add(new VaccinationTable() { VaccinationID = 1, Name = "Shot1", Info = "Enlarge CategoryDescription", Time = 1 });
        //        Vaccines.Add(new VaccinationTable() { VaccinationID = 2, Name = "Shot2", Info = "Enlarge Big CategoryDescription", Time = 2 });
        //        Vaccines.Add(new VaccinationTable() { VaccinationID = 3, Name = "Shot3", Info = "Enlarge Bigger CategoryDescription", Time = 2 });
        //        Vaccines.Add(new VaccinationTable() { VaccinationID = 4, Name = "Shot4", Info = "Enlarge Bigger Bigger CategoryDescription", Time = 2 });
        //        Vaccines.Add(new VaccinationTable() { VaccinationID = 3, Name = "Shot5", Info = "Enlarge Bigger CategoryDescription", Time = 2 });
        //    }
        //}
        /*
        void BehaviorGenerateBookInfo()
        {
            educationInfo = new ObservableCollection<Models.Education.Article>();
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.BEHAVIOR.ToString(), Title = "Are Time-Outs Helpful or Harmful to Young Children?", URL = "https://www.zerotothree.org/resources/324-are-time-outs-helpful-or-harmful-to-young-children" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.BEHAVIOR.ToString(), Title = "Helping Young Children Channel Their Aggression", URL = "https://www.zerotothree.org/resources/12-helping-young-children-channel-their-aggression" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.BEHAVIOR.ToString(), Title = "Coping with Defiance: Birth to Three Years", URL = "https://www.zerotothree.org/resources/199-coping-with-defiance-birth-to-three-years" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.BEHAVIOR.ToString(), Title = "Coping With Aggression and Teaching Self-Control", URL = "https://www.zerotothree.org/resources/233-coping-with-aggression-and-teaching-self-control" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.BEHAVIOR.ToString(), Title = "Positive Parenting Approaches", URL = "https://www.zerotothree.org/parenting/positive-parenting-approaches" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.BEHAVIOR.ToString(), Title = "How to Ease Your Child's Separation Anxiety", URL = "https://www.healthychildren.org/English/ages-stages/toddler/Pages/Soothing-Your-Childs-Separation-Anxiety.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.BEHAVIOR.ToString(), Title = "Nightmares and Night Terrors in Preschoolers", URL = "https://www.healthychildren.org/English/ages-stages/preschool/Pages/Nightmares-and-Night-Terrors.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.BEHAVIOR.ToString(), Title = "Gender Identity Development in Children", URL = "https://www.healthychildren.org/English/ages-stages/gradeschool/Pages/Gender-Identity-and-Gender-Confusion-In-Children.aspx" });
            educationInfo.Add(new Models.Education.Article { Category = Models.Education.EducationCategory.BEHAVIOR.ToString(), Title = "How to Shape & Manage Your Young Child's Behavior", URL = "https://www.healthychildren.org/English/family-life/family-dynamics/communication-discipline/Pages/How-to-Shape-Manage-Young-Child-Behavior.aspx" });
        }
        */
    }
}