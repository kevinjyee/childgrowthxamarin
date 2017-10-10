#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChartSample
{
    public class ViewModel
    {
		public ObservableCollection<Model> YearData{get;set;}
		public ObservableCollection<Model> QuarterData{get;set;}
		public ObservableCollection<Model> MonthData{get;set;}
		public ObservableCollection<Model> WeekData{get;set;}

		public ViewModel()
		{
			YearData = new ObservableCollection<Model>();
			QuarterData = new ObservableCollection<Model>();
			MonthData = new ObservableCollection<Model>();
			WeekData = new ObservableCollection<Model>();

			DateTime date = new DateTime (2014, 1, 1);		
			Random rand = new Random ();

			for (int i = 0; i < 365; i++) 
			{
				Model model = new Model (date.AddDays (i), rand.Next (10, 70));
		

				if (i < 7)
					WeekData.Add (model);

				if (i <= 30)
					MonthData.Add(model);

				if (i<= 92)
					QuarterData.Add(model);

				YearData.Add(model);
			}
		}

    }
}
