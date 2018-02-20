#region Using

using System;
using CoreLocation;
using MapKit;
using UIKit;
using Users.MobileClient.Helpers;
using Users.MobileClient.Models;

#endregion

namespace Users.MobileClient
{
    public partial class UserDetailsViewController : UIViewController
    {
        #region Properties

        public User User { get; set; }

        #endregion

        #region Fields

        private const double spanDelta = 0.05d;

        private UsersRepository usersRepository;

        #endregion

        #region Constructor

        public UserDetailsViewController(IntPtr handle) : base(handle)
        {
        }

        #endregion

        #region Event handlers

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            usersRepository = await UsersRepository.GetInstance();

            MapViewAddress.ScrollEnabled = true;
            MapViewAddress.ZoomEnabled = true;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            DisplayUserData();

            UpdateMap(User.Address.Geo.ToCLLocationCoordinate2D());

            // Used for a screenshot in Fig. 7-1
            //UpdateMap(new CLLocationCoordinate2D(40.7127837, -74.0059413));
        }

        partial void ButtonCancel_TouchUpInside(UIButton sender)
        {
            DismissViewController(true, null);
        }

        partial void ButtonUpdate_TouchUpInside(UIButton sender)
        {
            UpdateUserData();

            ButtonCancel_TouchUpInside(sender);
        }

        #endregion

        #region Methods (Private)

        private void DisplayUserData()
        {
            TextFieldName.Text = User.Name;
            TextFieldEmail.Text = User.Email;
        }

        private void UpdateUserData()
        {
            User.Name = TextFieldName.Text;
            User.Email = TextFieldEmail.Text;

            usersRepository.Update(User);
        }

        private void UpdateMap(CLLocationCoordinate2D centerCoordinate)
        {
            AddPin(centerCoordinate);

            SetMapRegion(centerCoordinate);
        }

        private void SetMapRegion(CLLocationCoordinate2D centerCoordinate)
        {
            var span = new MKCoordinateSpan(spanDelta, spanDelta);

            var region = new MKCoordinateRegion(centerCoordinate, span);

            MapViewAddress.SetRegion(region, false);
        }

        private void AddPin(CLLocationCoordinate2D centerCoordinate)
        {
            var pin = new PinMapAnnotation(centerCoordinate, User.Name);

            MapViewAddress.AddAnnotation(pin);
        }

        #endregion
    }
}