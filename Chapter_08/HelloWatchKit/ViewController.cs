#region Using

using System;
using UIKit;
using UserNotifications;

#endregion

namespace HelloWatchKit
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
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void ButtonLocalNotification_TouchUpInside(UIButton sender)
        {
            // Notification content
            var notificationContent = new UNMutableNotificationContent()
            {
                Title = "Hello",
                Body = "Local notification was fired",
            };

            // Notification will be fired after 10 seconds
            var notificationTrigger = UNTimeIntervalNotificationTrigger.CreateTrigger(10, false);

            // Notification request
            var notificationRequest = UNNotificationRequest.FromIdentifier(
                Guid.NewGuid().ToString(), notificationContent, notificationTrigger);

            UNUserNotificationCenter.Current.AddNotificationRequest(notificationRequest, null);
        }

        #endregion
    }
}
