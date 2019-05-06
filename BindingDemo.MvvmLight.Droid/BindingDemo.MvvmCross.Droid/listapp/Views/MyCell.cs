using System;
using BindingDemo.MvvmCross.Core;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace listapp.Views
{
    public partial class MyCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("MyCell");
        public static readonly UINib Nib;

        static MyCell()
        {
            Nib = UINib.FromName("MyCell", NSBundle.MainBundle);
        }

        protected MyCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            this.DelayBind(() =>
            {
                this.CreateBinding().For((cell) => cell.label.Text).To((CollectionElement el) => el.Name).Apply();
            });

            leftB.TouchUpInside += (obj, ea) => label.Text += "left ";
            rightB.TouchUpInside += (obj, ea) => label.Text += "right ";
        }
    }
}
