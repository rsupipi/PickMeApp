using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride_Share.Core.Model
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
