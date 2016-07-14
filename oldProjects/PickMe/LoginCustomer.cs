using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PickMe
{
    [Activity(Label = "Login Customer", MainLauncher =false)]
    public class LoginCustomer : Activity
    {


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "LoginCustomerView" layout resource
            SetContentView(Resource.Layout.LoginCustomerView);
        }
    }
}