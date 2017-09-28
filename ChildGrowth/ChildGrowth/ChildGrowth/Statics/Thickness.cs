using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChildGrowth.Statics
{
    public static class Thicknesses
    {
        public static Thickness Empty
        {
            get { return new Thickness(0, 0, 0, 0); }
        }

        public static Thickness IosStatusBar
        {
            get { return new Thickness(0, 20, 0, 0); }
        }
    }
}
