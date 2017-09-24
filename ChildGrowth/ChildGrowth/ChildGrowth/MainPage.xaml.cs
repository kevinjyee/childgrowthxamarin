using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChildGrowth
{
    public partial class MainPage : ContentPage
    {
        LineSeries childGraph;
        ItemsSeries items;
        public MainPage()
        {
            InitializeComponent();
            childGraph = new LineSeries();
            childGraph.Points.Add(new DataPoint(0, 0));
            childGraph.Points.Add(new DataPoint(100, 40));
        }

    }
}
