#region Using

using System;
using System.Diagnostics;
using Foundation;
using UIKit;

#endregion

namespace Navigation
{
    public partial class FirstViewController : BaseViewController
    {
        #region Constructor

        public FirstViewController(IntPtr handle) : base(handle)
        {
        }

        #endregion

        #region Methods (Public)

        [Action("UnwindToFirstViewController:")]
        public void UnwindToFirstViewController(UIStoryboardSegue segue)
        {
            Debug.WriteLine("UnwindToFirstViewController");
        }

        #endregion
    }
}