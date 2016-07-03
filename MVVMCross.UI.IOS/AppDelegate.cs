using System;
using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using UIKit;

namespace MVVMCross.UI.IOS
{
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate
    {
        UIWindow window;

        public override Boolean FinishedLaunching(UIApplication app, NSDictionary options)
        {
            window = new UIWindow(UIScreen.MainScreen.Bounds);

            var presenter = new MvxIosViewPresenter(this, window);

            var setup = new Setup(this, presenter);

            setup.Initialize();

            var startup = Mvx.Resolve<IMvxAppStart>();

            startup.Start();

            window.MakeKeyAndVisible();

            return true;
        }
    }
}


