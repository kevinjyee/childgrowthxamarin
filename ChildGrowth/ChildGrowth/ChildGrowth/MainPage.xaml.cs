
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Syncfusion.SfChart.XForms;
using System.Collections.ObjectModel;
using ChildGrowth.Pages.Child;
using System.ComponentModel;

namespace ChildGrowth
{
    public partial class MainPage : ContentPage
    {

        

        public MainPage()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Clears the values of Height, Weight, Head
        /// </summary>
        void OnCancelClicked(object sender, EventArgs args)
        {
            HeightEntry.Text = "";
            WeightEntry.Text = "";
            HeadEntry.Text = "";
        }
        double ageW = 1.0;
        double ageH = 1.0;
        
        /// <summary>
        /// Submit Height, Weight, and HeadC
        /// </summary>
        void OnSubmitClicked(object sender, EventArgs args)
        {
            Double Height = 0;
            Double Weight = 0;
            Double HeadC = 0;

            try
            {
                Height = Double.Parse(HeightEntry.Text);
            }
            catch
            {
            }
            try
            {
                Weight = Double.Parse(WeightEntry.Text);
            }
            catch
            {
            }
            try
            {
                HeadC = Double.Parse(HeadEntry.Text);
            }
            catch
            {
            }

            Button button = (Button)sender;

           ageW += 0.5;
           var result = new Points(ageW,Weight);
           viewModel.InputData.Add(result);
        }

        //TODO STEFAN: Prompt a change of graph
        async void OnWeightClicked(object sender, EventArgs args)
        {
            viewModel.ChartTitle = "Weight";
            viewModel.LineData.Clear();
            WHOData weightData = new WHOData();

            Dictionary<WHOData.Percentile, List<double>> weightByGender;
            List<Double> weightList;

            weightData.weightPercentile.TryGetValue(WHOData.Sex.Male, out weightByGender);
            weightByGender.TryGetValue(WHOData.Percentile.P3, out weightList);

            for (int i = 0; i < weightData.ageList.Count(); i++)
            {
                viewModel.LineData.Add(new Points(weightData.ageList[i], weightList[i]));
            }
        }

        //TODO STEFAN: Prompt a change of graph
        void OnHeightClicked(object sender, EventArgs args)
        {
            viewModel.ChartTitle = "Height";
            viewModel.LineData.Clear();
            WHOData heightData = new WHOData();

            Dictionary<WHOData.Percentile, List<double>> heightByGender;
            List<Double> heightList;

            heightData.heightPercentile.TryGetValue(WHOData.Sex.Male, out heightByGender);
            heightByGender.TryGetValue(WHOData.Percentile.P3, out heightList);

            for (int i = 0; i < heightData.ageList.Count(); i++)
            {
                if (heightData.ageList.Count() == heightList.Count)
                {
                    var result = new Points(heightData.ageList[i], heightList[i]);
                    viewModel.LineData.Add(result);
                }
            }
        }

        //TODO STEFAN: Prompt a change of graph
        async void OnHeadClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            await DisplayAlert("Clicked!",
                "The button labeled '" + button.Text + "' has been clicked",
                "OK");
        }

        async void Handle_FabClicked(object sender, System.EventArgs e)

        {
            var leadDetailPage = new ChildEntry();

            await Navigation.PushModalAsync(leadDetailPage);
        }



        private void UpdateButtonColor(Color color)

        {

            var normal = color;

            var disabled = color.MultiplyAlpha(0.25);



            fabBtn.NormalColor = normal;

            fabBtn.DisabledColor = disabled;

        }
    }

    public class Points : INotifyPropertyChanged
    {
        public Points(double age, double val)
        {
            Age = age;
            Val = val;
        }

        private double age;
        private double val;

        public double Age {
            get {
                return age;
            }
            set
            {
                age = value;
                NotifyPropertyChanged("Age");
            }
        }

        public double Val
        {
            get
            {
                return val;
            }
            set
            {
                val = value;
               NotifyPropertyChanged("Val");
            }
        }
 
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    public class ViewModel
    {

        public String ChartTitle { get; set; }

        private ObservableCollection<Points> lineData;

        public ObservableCollection<Points> LineData
        {
            get { return lineData; }
            set { lineData = value; }
        }


        private ObservableCollection<Points> inputData;

        public ObservableCollection<Points> InputData
        {
            get { return inputData; }
            set { inputData = value; }
        }

        public ViewModel()
        {
            ChartTitle = "Weight";
            LineData = new ObservableCollection<Points>();
            WHOData weightData = new WHOData();

            Dictionary<WHOData.Percentile, List<double>> weightByGender;
            List<Double> weightList;

            weightData.weightPercentile.TryGetValue(WHOData.Sex.Male, out weightByGender);
            weightByGender.TryGetValue(WHOData.Percentile.P3, out weightList);

            for (int i = 0; i < weightData.ageList.Count(); i++)
            {
                LineData.Add(new Points(weightData.ageList[i], weightList[i]));
            }

            InputData = new ObservableCollection<Points>();
            List<Double> weightList2;
            weightByGender.TryGetValue(WHOData.Percentile.P90, out weightList2);
            for (int i = 0; i < weightData.ageList.Count(); i++)
            {
                //InputData.Add(new Points(weightData.ageList[i], weightList2[i]));
            }
            InputData.Add(new Points(1, 1));
        }
    }
}
