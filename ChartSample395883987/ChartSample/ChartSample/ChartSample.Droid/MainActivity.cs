using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Syncfusion.Charts;

namespace ChartSample.Droid
{
    [Activity(Label = "ChartSample", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            
            //OnTouchListenerExt ex =  new OnTouchListenerExt();
            Xamarin.Forms.Forms.ViewInitialized += (sender, e) =>
            {
                if (!(e.NativeView is SfChart)) return;

               // (e.NativeView as SfChart).SetOnTouchListener(new OnTouchListenerExt());
            };

            LoadApplication(new App());
        }
    }

    public class OnTouchListenerExt : Java.Lang.Object, View.IOnTouchListener
    {
        public bool OnTouch(View v, MotionEvent e)
        {
            return false;
        }

        bool View.IOnTouchListener.OnTouch(View v, MotionEvent e)
        {
            return false;
        }

        IntPtr IJavaObject.Handle
        {
            get { return IntPtr.Zero; }
        }

        void IDisposable.Dispose()
        {
            
        }
    }
}

