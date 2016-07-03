using MvvmCross.iOS.Views;
using MVVMCross.Core;
using MvvmCross.Binding.BindingContext;

namespace MVVMCross.UI.IOS
{
    public partial class MainView : MvxViewController
    {
        public new MainViewModel ViewModel
        {
            get { return (MainViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public MainView()
            : base("MainView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var bindingSet = this.CreateBindingSet<MainView, MainViewModel>();

            bindingSet.Bind(Subtotal)
               .For(v => v.Text)
               .To(vm => vm.SubTotal);

            bindingSet.Bind(TipPercent)
               .For(v => v.Text)
               .To(vm => vm.TipPercent);

            bindingSet.Bind(TipPercentSlider)
               .For(v => v.Value)
               .To(vm => vm.TipPercent);

            bindingSet.Bind(TipValue)
               .For(v => v.Text)
               .To(vm => vm.TipValue)
               .OneWay();

            bindingSet.Bind(Total)
               .For(v => v.Text)
               .To(vm => vm.Total)
               .OneWay();

            bindingSet.Apply();
        }
    }
}


