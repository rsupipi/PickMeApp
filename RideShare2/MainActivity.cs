﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace RideShare2
{
    [Activity(Label = "Ride Share", Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            ImageButton homepageButton = FindViewById<ImageButton>(Resource.Id.imageButtonHome);
            homepageButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(CustomerLoginActivity));               
                StartActivity(intent);
            };

        }
    }
}

