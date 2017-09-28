using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChildGrowth.Statics
{
    public static class FontSizes
    {
        public readonly static double _120PercentOfSmall = Device.GetNamedSize(NamedSize.Small, typeof(Label)) * 1.2;
        public readonly static double _150PercentOfLarge = Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 1.5;
    }
}
