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

namespace RideShare.Core.Repository
{
    public class Path
    {
        public static String rootURL()
        {
            return "http://172.28.42.91:3000/pickme/";
        }
    }
}