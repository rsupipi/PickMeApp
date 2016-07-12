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
using RideShare2.Model;

using System.Threading.Tasks;
//using System.Web.Script.Serialization;
using System.IO;
using System.Net;
using Newtonsoft.Json;


namespace RideShare2.Repository
{
   public class CustomerRepository
    {

        /** Handle the customer loging */
        public static Customer loginCustomer(String userName, String password)
        {
            //string URI = "customers/login";
            string URI = Path.rootURL()+"customers/login";

            string myParameters = "phone="+userName+"&password="+password;
            Customer user = null;
            
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string json = wc.UploadString(URI, myParameters);
                Console.WriteLine(json);
                
                CustomersList sh = JsonConvert.DeserializeObject<CustomersList>(json);
                                
                try
                {
                    foreach (Customer c in sh.Customers)
                    {
                        user = c;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return user;
        }



        /** Handle the add custmer function*/
        public static bool addCustomer(Customer customer)
        {
            //string URI = "http://172.28.42.91:3000/pickme/customers";
            string URI = Path.rootURL() + "customers";
            ResponseStatus responseStatus;

            string myParameters = "name=" + customer.name + "&email=" + customer.email + "&phone=" + customer.phone + "&password=" + customer.password;
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string json = wc.UploadString(URI, myParameters);

                responseStatus = JsonConvert.DeserializeObject<ResponseStatus>(json);

            }

            return responseStatus.Error;
        }
    }

    /** Handle the customer list*/
    class CustomersList
    {
        public List<Customer> Customers { get; set; }

    }

    /** Get response state*/
    public class ResponseStatus
    {
        public bool Error { set; get; }
    }


}



