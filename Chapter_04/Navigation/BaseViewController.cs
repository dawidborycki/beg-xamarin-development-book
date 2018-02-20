#region Using

using System;
using System.Diagnostics;
using Foundation;
using UIKit;

#endregion

namespace Navigation
{
    public class BaseViewController : UIViewController
    {
        #region Constructor

        protected BaseViewController(IntPtr handle) : base(handle) { }

        #endregion

        #region Methods (Public)

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            var sourceViewControllerName = segue.SourceViewController.GetType().Name;
            var destinationViewControllerName = segue.DestinationViewController.GetType().Name;

            Debug.WriteLine($"From: {sourceViewControllerName} " +
                $"To: {destinationViewControllerName}");
        }

        #endregion
    }
}
