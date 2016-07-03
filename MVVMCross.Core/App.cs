using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace MVVMCross.Core
{
    public class App : MvxApplication
    {
        #region Methods

        public override void Initialize()
        {
            Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<MainViewModel>());
        }

        #endregion
    }
}

