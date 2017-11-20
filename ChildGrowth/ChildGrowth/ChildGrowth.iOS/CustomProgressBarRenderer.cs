using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CoreGraphics;

[assembly: ExportRenderer(typeof(CustomProgressBar), typeof(ChildGrowth.iOS.CustomProgressBarRenderer))]
namespace ChildGrowth.iOS
{
    class CustomProgressBarRenderer : ProgressBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);

            
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            var X = 1.0f;
            var Y = 30.0f; // This changes the height

            CGAffineTransform transform = CGAffineTransform.MakeScale(X, Y);
            this.Transform = transform;
        }
    }
    }