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

namespace RideShare2.Model
{
    public class Vehicle
    {


        public String vhecle_number
        {
            get;
            set;
        }

        public String type
        {
            get;
            set;
        }

        public String brand
        {
            get;
            set;
        }

        public String model
        {
            get;
            set;
        }

        public int seets
        {
            get;
            set;
        }

        public String status
        {
            get;
            set;
        }

        public String details
        {
            get;
            set;
        }


    }
}