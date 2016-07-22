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
using RideShare2.Repository;

namespace RideShare2
{
    [Activity(Label = "Register")]
    public class RegisterCustomerActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.RegisterCustomer);

            
            EditText textName = FindViewById<EditText>(Resource.Id.textCName);
            EditText textEmail = FindViewById<EditText>(Resource.Id.textCEmail);
            EditText textPhone = FindViewById<EditText>(Resource.Id.textCphoneNo);
            EditText textPassword = FindViewById<EditText>(Resource.Id.textCpassword);

            Button buttonCreate = FindViewById<Button>(Resource.Id.buttonCustomerCreate);


            /** Register Customer and  goto customer home page*/
            buttonCreate.Click += (object sender, EventArgs e) =>
            {


                Customer customer = new Customer { name = textName.Text, email = textEmail.Text, phone = Int32.Parse(textPhone.Text), password = textPassword.Text };
                //Customer customer = new Customer { name = "test1", email = "test@gmail.com", phone = 55252, password = "123" };
                bool status = CustomerRepository.addCustomer(customer);

                var messageDialog = new AlertDialog.Builder(this);
                if (status)
                {

                    messageDialog.SetMessage("Account not created");
                    messageDialog.SetNeutralButton("Ok", delegate {
                       
                    });
                    //callDialog.SetNegativeButton(password, delegate { });

                    // Show the alert dialog to the user and wait for response.
                    messageDialog.Show();
                }
                else
                {
                    messageDialog.SetMessage("The account created successfully!");
                    messageDialog.SetNeutralButton("Ok", delegate {
                        var intent = new Intent(this, typeof(CustomerHomeActivity));
                        List<string> userData = new List<string>();
                        int phoneNu = customer.phone;
                        userData.Add(phoneNu.ToString());
                        intent.PutStringArrayListExtra("userData", userData);
                        StartActivity(intent);

                    });
                    messageDialog.Show();
                    
                }
                
            };

        }
    }
}