// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TipCalc.UI.iOS
{
    [Register("MainViewController")]
    partial class MainViewController
    {
        [Outlet]
        UIKit.UITextField Subtotal { get; set; }

        [Outlet]
        UIKit.UITextField TipPercent { get; set; }

        [Outlet]
        UIKit.UISlider TipPercentSlider { get; set; }

        [Outlet]
        UIKit.UITextField TipValue { get; set; }

        [Outlet]
        UIKit.UITextField Total { get; set; }

        [Outlet]
        UIKit.UIScrollView ScrollView { get; set; }

        [Action("showInfo:")]
        partial void showInfo(Foundation.NSObject sender);

        void ReleaseDesignerOutlets()
        {
            if (ScrollView != null)
            {
                ScrollView.Dispose();
                ScrollView = null;
            }

            if (Subtotal != null)
            {
                Subtotal.Dispose();
                Subtotal = null;
            }

            if (TipPercent != null)
            {
                TipPercent.Dispose();
                TipPercent = null;
            }

            if (TipPercentSlider != null)
            {
                TipPercentSlider.Dispose();
                TipPercentSlider = null;
            }

            if (TipValue != null)
            {
                TipValue.Dispose();
                TipValue = null;
            }

            if (Total != null)
            {
                Total.Dispose();
                Total = null;
            }
        }
    }
}