#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
using System.Diagnostics;


#endregion
using Syncfusion.RangeNavigator.XForms;
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChartSample
{
    public partial class RangeNavigatorGettingStarted
    {

		ColumnSeries series1 ;

        public RangeNavigatorGettingStarted()
        {
            InitializeComponent();

			 series1 = new ColumnSeries () {
				ItemsSource = series.ItemsSource,
				XBindingPath = "XValue",
				YBindingPath = "YValue"
			};

            ((SfChart)RangeNavigator.Content).Series.Clear();
			((SfChart)RangeNavigator.Content).Series.Add(series1);

			dateTimeAxis.ActualRangeChanged  += DateTimeAxis_ActualRangeChanged;

            if (Device.OS == TargetPlatform.Android)
            {
                RangeNavigator.HeightRequest = 150;
            }
            else if (Device.OS == TargetPlatform.iOS)
            {
                RangeNavigator.HeightRequest = 100;
            }

        }

//        void DateTimeAxis_ActualRangeChanged (object sender, ActualRangeChangedEventArgs e)
//        {
//			dateTimeAxis.
//        }

        void nac_RangeChanged(object sender, Syncfusion.RangeNavigator.XForms.RangeChangedEventArgs e)
        {
            dateTimeAxis.Minimum = e.ViewRangeStartDate;
            dateTimeAxis.Maximum = e.ViewRangeEndDate;

        }
    }
}