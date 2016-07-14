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
    public class Customer
    {

        public int phone
        {
            get;
            set;
        }

        public String name
        {
            get;
            set;
        }

        public String email
        {
            get;
            set;
        }

        public String password
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