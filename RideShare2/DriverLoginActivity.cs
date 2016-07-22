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
    [Activity(Label = "Driver's Login", Icon = "@drawable/icon")]
    public class DriverLoginActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DriverLogin);

            Button buttonLogin = FindViewById<Button>(Resource.Id.buttonLoginDriver);
            EditText textUserName = FindViewById<EditText>(Resource.Id.editTextDriverUserName);
            EditText textPassword = FindViewById<EditText>(Resource.Id.editTexTDriverPw);

            Button buttonFortPw = FindViewById<Button>(Resource.Id.buttonDriverFP);
            Button buttonRegister = FindViewById<Button>(Resource.Id.buttonDriverRegister);


            /** Process Driver login and redirect to Driver's home page*/
            buttonLogin.Click += (object sender, EventArgs e) =>
            {
                String userName = textUserName.Text;
                String password = textPassword.Text;

                Driver driver = DriverRepository.loginDriver(userName, password);
                                
                if (driver == null)
                {
                    var msgWindow = new AlertDialog.Builder(this);
                    msgWindow.SetMessage("Incorrect user name or password!");
                    msgWindow.SetNeutralButton("Ok", delegate {
                        // Create intent to dial phone

                    });
                    //callDialog.SetNegativeButton(password, delegate { });

                    // Show the alert dialog to the user and wait for response.
                    msgWindow.Show();
                }
                else
                {
                    var intent = new Intent(this, typeof(DriverHomeActivity));
                    
                    //intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
                    List<string> userData = new List<string>();                    
                    userData.Add(driver.name);
                    intent.PutStringArrayListExtra("userData", userData);
                    StartActivity(intent);
                }

            };


            /** Customer Registration */

            buttonRegister.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(RegisterCustomerActivity));
                StartActivity(intent);
            };


            /** Navigate to Customer loging page */
            ImageButton driverLoginButton = FindViewById<ImageButton>(Resource.Id.imageButtonCustomerLogin);
            driverLoginButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(CustomerLoginActivity));
                StartActivity(intent);
            };

        }
    }
}
