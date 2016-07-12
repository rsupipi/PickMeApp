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
using RideShare2.Repository;
using RideShare2.Model;

namespace RideShare2
{
    [Activity(Label = "Login", Icon = "@drawable/icon")]
    public class CustomerLoginActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CustomerLogin);

            Button buttonLogin = FindViewById<Button>(Resource.Id.buttonLoginCustomer);
            EditText textUserName = FindViewById<EditText>(Resource.Id.editTextCustomerUserName);
            EditText textPassword = FindViewById<EditText>(Resource.Id.editTexTCustomerPw);

            Button buttonFortPw = FindViewById<Button>(Resource.Id.buttonCustomerFP);
            Button buttonRegister = FindViewById<Button>(Resource.Id.buttonCustomerRegister);
            

            /** Process Customer login goto customer home page*/
            buttonLogin.Click += (object sender, EventArgs e) =>
            {

                String userName = textUserName.Text;
                String password = textPassword.Text;

                Customer customer = CustomerRepository.loginCustomer(userName, password);
                if(customer == null)
                {
                    var callDialog = new AlertDialog.Builder(this);
                    callDialog.SetMessage("Incorrect user name or password!");
                    callDialog.SetNeutralButton("Ok", delegate {
                        // Create intent to dial phone

                    });
                    //callDialog.SetNegativeButton(password, delegate { });

                    // Show the alert dialog to the user and wait for response.
                    callDialog.Show();
                }
                else
                {
                    var intent = new Intent(this, typeof(CustomerHomeActivity));
                    //intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
                    List<string> userData = new List<string>();
                    int phoneNu = customer.phone;                    
                    userData.Add(phoneNu.ToString());
                    intent.PutStringArrayListExtra("userData",userData);
                    StartActivity(intent);
                }
                
            };


            /** Customer Registration */
            
            buttonRegister.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(RegisterCustomerActivity));
                StartActivity(intent);
            };

        }
    }
 }