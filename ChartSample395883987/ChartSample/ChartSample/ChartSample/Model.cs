#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartSample
{
    public class Model
	{ 
		public DateTime XValue {
			get;
			set;
		}

		public double YValue {
			get;
			set;
		}

		public Model(DateTime value1, double value2)
		{
			XValue = value1;
			YValue = value2;
		}

    }
}