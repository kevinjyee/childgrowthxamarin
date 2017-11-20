using System.Drawing;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(CustomProgressBar), typeof(ChildGrowth.Android.Renderers.CustomProgressBarRenderer))]

namespace ChildGrowth.Android.Renderers
{
    
    public class CustomProgressBarRenderer : ProgressBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ProgressBar> e)
        {
            base.OnElementChanged(e);


            //Control.ProgressTintList = Android.Content.Res.ColorStateList.ValueOf(Color.AliceBlue()); //Change the color
            Control.ScaleY = 30; //Changes the height
            Control.ScaleX = 0.5f;

        }
    }
}