﻿#region Using

using System;
using System.Threading.Tasks;
using UIKit;

#endregion

namespace BackgroundUpdate
{
    public partial class ViewController : UIViewController
    {
        #region Fields

        private bool isTimerActive = false;

        #endregion

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
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void ButtonRunTimer_TouchUpInside(UIButton sender)
        {
            if (!isTimerActive)
            {
                isTimerActive = true;

                Task.Run(UpdateTimer);
            }
        }

        #endregion

        #region Methods (Private)

#pragma warning disable RECS0135
        private Task UpdateTimer()
#pragma warning restore RECS0135 
        {
            while (true)
            {
                InvokeOnMainThread(() =>
                {
                    LabelTime.Text = DateTime.Now.ToLongTimeString();
                });

                Task.Delay(1000).Wait();
            }
        }

        #endregion
    }
}
