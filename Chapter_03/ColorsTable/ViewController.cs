﻿#region Using

using System;
using ColorsTable.Colors;
using UIKit;

#endregion

namespace ColorsTable
{
    public partial class ViewController : UIViewController
    {
        #region Constructor

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        #endregion

        #region Event handlers

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var table = new UITableView(View.Frame)
            {
                Source = new ColorsTableSource(this)
            };

            Add(table);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        #endregion
    }
}
