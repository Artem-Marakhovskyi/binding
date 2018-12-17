
using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;

namespace BindingDemo.MvvmCross.Droid
{
    [Activity(
        Label = "MvvmCross sample", MainLauncher = true, NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashView : MvxSplashScreenActivity<MvxAndroidSetup<Core.App>, Core.App>
    {
    }
}
