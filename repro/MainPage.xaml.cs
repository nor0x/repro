using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace repro
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public event EventHandler<BoundsEventArgs> ButtonPositionChanged;

        public MainPage()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var top = Button2.Margin.Top + 70;
            Button2.Margin = new Thickness(Button2.Margin.Left, top, Button2.Margin.Right, Button2.Margin.Bottom);
            var newbounds = new Rectangle();
            ButtonPositionChanged?.Invoke(this, new BoundsEventArgs(newbounds));
            System.Diagnostics.Debug.WriteLine("Y: " + Button2.Y + " height: " + Button2.Height);
        }

        void Button_ClickedUp(System.Object sender, System.EventArgs e)
        {
            var top = Button2.Margin.Top - 70;
            Button2.Margin = new Thickness(Button2.Margin.Left, top, Button2.Margin.Right, Button2.Margin.Bottom);
            var newbounds = new Rectangle();
            ButtonPositionChanged?.Invoke(this, new BoundsEventArgs(newbounds));
            System.Diagnostics.Debug.WriteLine("Y: " + Button2.Y + " height: " + Button2.Height);
        }
    }

    public class BoundsEventArgs : EventArgs
    {
        public Rectangle Bounds { get; set; }

        public BoundsEventArgs(Rectangle r)
        {
            Bounds = r;
        }
    }
}
