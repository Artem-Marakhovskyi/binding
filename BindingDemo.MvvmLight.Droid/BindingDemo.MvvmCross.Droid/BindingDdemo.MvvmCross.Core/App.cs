using BindingDemo.MvvmCross.Core.ViewModels;
using MvvmCross.ViewModels;

namespace BindingDemo.MvvmCross.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<MainViewModel>();
        }
    }
}
