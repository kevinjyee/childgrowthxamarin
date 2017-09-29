using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Xamarin.Forms;
using Syncfusion.SfChart.XForms;

namespace ChildGrowth.Statics
{
    public static class Fonts
    {
        public static Font SystemFontAt150PercentOfLarge = Font.SystemFontOfSize(Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 1.5);
        public static Font SystemFontAt120PercentOfLarge = Font.SystemFontOfSize(Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 1.2);

        public static Font SystemFontAt60PercentOfDefault = Font.SystemFontOfSize(Device.GetNamedSize(NamedSize.Default, typeof(ChartAxisTitle)) * 0.6);
        public static Font SystemFontAt170PercentOfDefault = Font.SystemFontOfSize(Device.GetNamedSize(NamedSize.Default, typeof(ChartAxisTitle)) * 1.7);
    }
}
