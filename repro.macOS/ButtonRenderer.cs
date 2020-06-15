using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using Foundation;
using repro;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

[assembly: ExportRenderer(typeof(Button), typeof(repro.macOS.Renderer.ButtonRenderer))]
namespace repro.macOS.Renderer
{
    public class ButtonRenderer : Xamarin.Forms.Platform.MacOS.ButtonRenderer
    {
        private Button _button;


        public ButtonRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            _button = e.NewElement;
            _button.PropertyChanged += _button_PropertyChanged;
            System.Diagnostics.Debug.WriteLine("e: " + e.NewElement.Text);
        }

        private void _button_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.PropertyName + " changed");
            if(sender is Button b)
            {
                if(b.Text.Contains("move"))
                {
                    System.Diagnostics.Debug.WriteLine("button: " + b.Y);
                    var uibutton = Control;
                    uibutton.NeedsDisplay = true;
                    uibutton.InvalidateIntrinsicContentSize();
                    uibutton.Layout();
                    uibutton.LayoutSubtreeIfNeeded();
                    var x = uibutton.Superview;
                    x.NeedsDisplay = true;
                    x.NeedsLayout = true;
                    x.LayoutSubtreeIfNeeded();
                    x.InvalidateIntrinsicContentSize();
                    x.Layout();
                }
            }

        }
    }
}