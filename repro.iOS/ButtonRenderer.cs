using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using Foundation;
using repro;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Button), typeof(repro.iOS.Renderer.ButtonRenderer))]
namespace repro.iOS.Renderer
{
    public class ButtonRenderer : Xamarin.Forms.Platform.iOS.ButtonRenderer
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
            if (sender is Button b)
            {
                if (b.Text.Contains("move"))
                {
                    System.Diagnostics.Debug.WriteLine("button: " + b.Y);
                }
            }
        }
    }
}