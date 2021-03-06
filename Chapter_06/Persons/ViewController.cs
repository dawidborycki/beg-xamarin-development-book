﻿#region Using

using System;
using Persons.Common.Models;
using UIKit;

#endregion

namespace Persons
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

        partial void ButtonDisplayPersonData_TouchUpInside(UIButton sender)
        {
            var defaultPerson = Person.Default();

            TextFieldFirstName.Text = defaultPerson.FirstName;
            TextFieldLastName.Text = defaultPerson.LastName;
            TextFieldAge.Text = defaultPerson.Age.ToString();
            TextFieldEmail.Text = defaultPerson.Email;
        }

        #endregion
    }
}
