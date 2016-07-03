using UIKit;
using System;
using Foundation;
using TipCalc.Core;

namespace TipCalc.UI.iOS
{
    public partial class MainViewController : UIViewController
    {
        private UIPopoverController flipsidePopoverController;

        private readonly Model info;

        public MainViewController(string nibName, NSBundle bundle)
            : base(nibName, bundle)
        {
            this.info = new Model()
            {
                TipPercent = 15,
            };

            this.info.TipValueChanged += (sender, e) =>
            {
                TipValue.Text = info.TipValue.ToString();
                Total.Text = info.Total.ToString();
            };
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.ScrollView.ContentSize = new CoreGraphics.CGSize(Total.Frame.Width, Total.Frame.Height + Total.Frame.Top);

            this.Subtotal.EditingDidEnd += (sender, e) =>
            {
                info.Subtotal = Parse(Subtotal);
            };

            this.TipPercent.EditingDidEnd += (sender, e) =>
            {
                info.TipPercent = Parse(TipPercent);
            };

            this.TipPercentSlider.ValueChanged += (sender, e) =>
            {
                TipPercent.Text = Math.Truncate(TipPercentSlider.Value).ToString();
                info.TipPercent = (decimal)TipPercentSlider.Value;
            };
        }

        private static decimal Parse(UITextField field)
        {
            if (field.Text == "")
                return 0m;
            try
            {
                return Convert.ToDecimal(field.Text);
            }
            catch (Exception)
            {
                field.Text = "";
                return 0m;
            }
        }

        public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
        {
            // Return true for supported orientations
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
            {
                return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
            }
            else
            {
                return true;
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        partial void showInfo(NSObject sender)
        {
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
            {
                var controller = new FlipsideViewController("FlipsideViewController", null)
                {
                    ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal,
                };
                controller.Done += delegate
                {
                    this.DismissModalViewController(true);
                };
                this.PresentModalViewController(controller, true);
            }
            else
            {
                if (flipsidePopoverController == null)
                {
                    var controller = new FlipsideViewController("FlipsideViewController", null);
                    flipsidePopoverController = new UIPopoverController(controller);
                    controller.Done += delegate
                    {
                        flipsidePopoverController.Dismiss(true);
                    };
                }
                if (flipsidePopoverController.PopoverVisible)
                {
                    flipsidePopoverController.Dismiss(true);
                }
                else
                {
                    flipsidePopoverController.PresentFromBarButtonItem((UIBarButtonItem)sender, UIPopoverArrowDirection.Any, true);
                }
            }
        }
    }
}
