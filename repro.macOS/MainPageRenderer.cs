using System;
using System.Collections.Generic;
using System.Linq;
using AppKit;
using CoreGraphics;
using Foundation;
using repro;
using repro.macOS.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

[assembly: ExportRenderer(typeof(MainPage), typeof(MainPageRenderer))]
namespace repro.macOS.Renderer
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
        }

        private void _page_ButtonPositionChanged(object sender, EventArgs e)
        {
            if (e is BoundsEventArgs bea)
            {
                System.Diagnostics.Debug.WriteLine("new bounds: " + bea.Bounds);
                var nview = NativeView;
                System.Diagnostics.Debug.WriteLine("nview : " + nview.Frame);
            }
        }

        public override void ViewDidAppear()
        {
            if (NSApplication.SharedApplication.MainWindow != null)
            {
                NSApplication.SharedApplication.MainWindow.Title = "test :-D";

                NSApplication.SharedApplication.MainWindow.BackgroundColor = NSColor.Yellow;
            }

        }
    }
}