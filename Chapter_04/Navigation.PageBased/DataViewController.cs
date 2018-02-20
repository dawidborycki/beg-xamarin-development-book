#region Using

using System;
using System.Collections.Generic;
using UIKit;

#endregion

namespace Navigation.PageBased
{
    public partial class DataViewController : UIViewController
    {
        #region Properties

        public KeyValuePair<string, UIColor> DataObject { get; set; }

        #endregion

        #region Constructor

        protected DataViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.        
        }

        #endregion

        #region Event handlers

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            dataLabel.Text = DataObject.Key;
            ViewDataPanel.BackgroundColor = DataObject.Value;
        }

        #endregion
    }
}
