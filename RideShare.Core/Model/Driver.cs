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
    public class Driver
    {
        public String NIC
        {
            get;
            set;
        }

        public String name
        {
            get;
            set;
        }

        public String title
        {
            get;
            set;
        }

        public int phoneNo
        {
            get;
            set;
        }

        public String Address
        {
            get;
            set;
        }

        public String license
        {
            get;
            set;
        }

        public String password
        {
            get;
            set;
        }

        public String email
        {
            get;
            set;
        }


    }
}
