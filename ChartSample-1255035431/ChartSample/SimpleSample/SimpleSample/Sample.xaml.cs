using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Syncfusion.SfChart.XForms;

namespace SimpleSample
{
    public partial class Sample : ContentPage
    {
        public Sample()
        {
            InitializeComponent();

        }

        void But_Clicked (object sender, EventArgs e)
        {
			viewModel.Models [2].Year2013 = 130;
        }

		void But1_Clicked (object sender, EventArgs e)
		{
			viewModel.Models.Add (new Model("Tablet",120,150));
		}
    }
		
}
