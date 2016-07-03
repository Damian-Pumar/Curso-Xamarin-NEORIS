using Android.App;
using MvvmCross.Droid.Views;

namespace MVVMCrossUI.Droid
{
    [Activity(Label = "MainActivity", MainLauncher = true)]
    public class MainActivity : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();

            this.SetContentView(this.layourResId);
        }
    }
}

