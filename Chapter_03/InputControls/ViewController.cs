#region Using

using System;
using CoreGraphics;
using UIKit;

#endregion

namespace InputControls
{
    public partial class ViewController : UIViewController
    {
        #region Fields

        private CGPoint initialSquareCenter;

        #endregion

        #region Constructor

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        #endregion

        #region Evetn handlers

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            StoreSquareCenter();

            AdjustSliderRange();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        #endregion

        #region Methods (Private)

        partial void SwitchIsVertical_ValueChanged(UISwitch sender)
        {
            RecenterSquare();

            AdjustSliderRange();
        }

        private void StoreSquareCenter()
        {
            initialSquareCenter = ViewMoveableSquare.Center;
        }

        partial void SliderShift_ValueChanged(UISlider sender)
        {
            TranslateSquare();
        }

        private void RecenterSquare()
        {
            ViewMoveableSquare.Center = initialSquareCenter;
        }

        private void AdjustSliderRange()
        {
            var margin = ViewMoveableSquare.Frame.Width / 2.0;
            var range = SwitchIsVertical.On ? View.Frame.Height : View.Frame.Width;
            var maxShiftValue = Convert.ToInt32(range / 2.0 - margin);

            SliderShift.MinValue = -maxShiftValue;
            SliderShift.MaxValue = maxShiftValue;
            SliderShift.Value = 0;
        }

        private void TranslateSquare()
        {
            var newCenter = new CGPoint(initialSquareCenter);

            if (!SwitchIsVertical.On)
            {
                newCenter.X += SliderShift.Value;
            }
            else
            {
                newCenter.Y += SliderShift.Value;
            }

            ViewMoveableSquare.Center = newCenter;
        }

        #endregion
    }
}
