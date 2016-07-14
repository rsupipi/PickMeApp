using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Ride_Share
{
    //[Activity(Label = "Ride Share", MainLauncher = true, Icon = "@drawable/icon")]
    [Activity(Label = "Ride Share")]
    public class MainActivity : Activity
    {
       

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.LoginCustomer);
            ImageButton ButtonHome = FindViewById<ImageButton>(Resource.Id.ButtonHome);

            ButtonHome.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(LoginCustomerActivity));               
                StartActivity(intent);
            };
            

        }
    }
}

