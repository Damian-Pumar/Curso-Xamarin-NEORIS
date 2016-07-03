using Android.App;
using MvvmCross.Droid.Views;
using MVVMCross.Core;

namespace MVVMCross.UI.Droid
{
    [Activity(Label = "MVVMCross TipCal Android", MainLauncher = true)]
    public class MainActivity : MvxActivity
    {
        public new MainViewModel ViewModel
        {
            get
            {
                return (MainViewModel)base.ViewModel;
            }
            set
            {
                base.ViewModel = value;
            }
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();

            this.SetContentView(Resource.Layout.MainView);
        }
    }
}