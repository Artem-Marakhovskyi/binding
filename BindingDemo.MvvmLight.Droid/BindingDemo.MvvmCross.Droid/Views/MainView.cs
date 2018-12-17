
using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using BindingDemo.MvvmCross.Core.ViewModels;
using MvvmCross.Binding;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;

namespace BindingDemo.MvvmCross.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Label = "View for ViewModel")]
    public class MainView : MvxActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.main_view);
        }
    }
}
