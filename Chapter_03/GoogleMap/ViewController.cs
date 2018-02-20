#region Using

using System;
using System.IO;
using CoreGraphics;
using Foundation;
using UIKit;

#endregion

namespace GoogleMap
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

            var webView = new UIWebView(GetFrameWithVerticalMargin(20));

            LoadMapUrl(webView);

            Add(webView);

            webView.LoadFinished += (sender, e) =>
            {
                webView.EvaluateJavascript("displayGeocoordinate('New York');");
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        #endregion

        #region Methods (Private)

        private CGRect GetFrameWithVerticalMargin(nfloat offset)
        {
            var rect = View.Frame;

            rect.Y = offset;
            rect.Height -= offset;

            return rect;
        }

        private void LoadMapUrl(UIWebView webView)
        {
            var url = Path.Combine(NSBundle.MainBundle.BundlePath, "HTML/map.html");

            webView.LoadRequest(new NSUrlRequest(new NSUrl(url, false)));
        }

        #endregion
    }
}
