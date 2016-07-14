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

namespace RideShare.Core.Model
{
    public class Booking
    {
        public String booking_id
        {
            get;
            set;
        }

        public String pickup_location
        {
            get;
            set;
        }

        public String drop_location
        {
            get;
            set;
        }

        public String status
        {
            get;
            set;
        }

    }

}
