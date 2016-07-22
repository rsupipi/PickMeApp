using System;
using System.Collections.Generic;
using RideShare2.Model;
using System.Net;
using Newtonsoft.Json;


namespace RideShare2.Repository
{
    class DriverRepository
    {

        /** Handle the driver loging */
        public static Driver loginDriver(String NIC, String password)
        {
            //string URI = "customers/login";
            string URI = Path.rootURL() + "drivers/login";

            string myParameters = "NIC=" + NIC + "&password=" + password;
            Driver user = null;

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string json = wc.UploadString(URI, myParameters);
                Console.WriteLine(json);

                DriversList sh = JsonConvert.DeserializeObject<DriversList>(json);

                try
                {
                    foreach (Driver d in sh.Drivers)
                    {
                        user = d;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("999999999999999" +e);
                }
            }

            return user;
        }


        /** Register Driver*/

        /** Handle the customer list*/
        class DriversList
        {
            public List<Driver> Drivers { get; set; }

        }

        /** Get response state*/

        /*public class ResponseStatus
        {
            public bool Error { set; get; }
        }
        */

    }
}