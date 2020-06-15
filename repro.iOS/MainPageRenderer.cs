using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using Foundation;
using repro;
using repro.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MainPage), typeof(MainPageRenderer))]
namespace repro.Renderer
{
    public class MainPageRenderer : PageRenderer
    {
        private MainPage _page;


        public MainPageRenderer()
        {
        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            _page = (MainPage)e.NewElement;
            _page.ButtonPositionChanged += _page_ButtonPositionChanged;

            var x = NativeView.Subviews;

        }

        private void _page_ButtonPositionChanged(object sender, EventArgs e)
        {
            if(e is BoundsEventArgs bea)
            {
                System.Diagnostics.Debug.WriteLine("new bounds: " + bea.Bounds);
                var nview = NativeView;
                System.Diagnostics.Debug.WriteLine("nview : " + nview.Frame);
            }
        }


        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }
    }
}