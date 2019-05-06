// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace listapp.Views
{
	[Register ("MyCell")]
	partial class MyCell
	{
		[Outlet]
		UIKit.UILabel label { get; set; }

		[Outlet]
		UIKit.UIButton leftB { get; set; }

		[Outlet]
		UIKit.UIButton rightB { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (label != null) {
				label.Dispose ();
				label = null;
			}

			if (rightB != null) {
				rightB.Dispose ();
				rightB = null;
			}

			if (leftB != null) {
				leftB.Dispose ();
				leftB = null;
			}
		}
	}
}
