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

using Android.Gms.Maps;
using Android.Gms.Maps.Model;


namespace RideShare2
{
    [Activity(Label = "Pickup Location")]
    public class CustomerHomeActivity : Activity
    {

        private Button externalMapButton;
        private FrameLayout mapFrameLayout;
        private MapFragment mapFragment;
        private GoogleMap googleMap;
        private LatLng rayLocation;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            rayLocation = new LatLng(50.846704, 4.352446);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.CustomerHome);
          
            
            //FindViews();
            externalMapButton = FindViewById<Button>(Resource.Id.externalMapButton);
            mapFrameLayout = FindViewById<FrameLayout>(Resource.Id.mapFrameLayout);


            // HandleEvents();
            externalMapButton.Click += ExternalMapButton_Click;



            //CreateMapFragment();
            mapFragment = FragmentManager.FindFragmentByTag("map") as MapFragment;

            if (mapFragment == null)
            {
                var googleMapOptions = new GoogleMapOptions()
                    .InvokeMapType(GoogleMap.MapTypeSatellite)
                    .InvokeZoomControlsEnabled(true)
                    .InvokeCompassEnabled(true);

                FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();
                mapFragment = MapFragment.NewInstance(googleMapOptions);
                fragmentTransaction.Add(Resource.Id.mapFrameLayout, mapFragment, "map");
                fragmentTransaction.Commit();
            }



            //UpdateMapView();
            var mapReadyCallback = new LocalMapReady();

            mapReadyCallback.MapReady += (sender, args) =>
            {
                googleMap = (sender as LocalMapReady).Map;

                if (googleMap != null)
                {
                    MarkerOptions markerOptions = new MarkerOptions();
                    markerOptions.SetPosition(rayLocation);
                    markerOptions.SetTitle("Your Location");
                    googleMap.AddMarker(markerOptions);

                    CameraUpdate cameraUpdate = CameraUpdateFactory.NewLatLngZoom(rayLocation, 15);
                    googleMap.MoveCamera(cameraUpdate);
                }
            };

            mapFragment.GetMapAsync(mapReadyCallback);
        }


       private class LocalMapReady : Java.Lang.Object, IOnMapReadyCallback
        {
            public GoogleMap Map { get; private set; }

            public event EventHandler MapReady;

            public void OnMapReady(GoogleMap googleMap)
            {
                Map = googleMap;
                var handler = MapReady;
                if (handler != null)
                    handler(this, EventArgs.Empty);
            }
        }

        private void ExternalMapButton_Click(object sender, EventArgs e)
        {
            /*
            Android.Net.Uri rayLocationUri = Android.Net.Uri.Parse("geo:6.830121,79.881093");
            Intent mapIntent = new Intent(Intent.ActionView, rayLocationUri);
            StartActivity(mapIntent);
            */

            /*var geoUri = Android.Net.Uri.Parse("geo:42.374260,-71.120824");
            var mapIntent = new Intent(Intent.ActionView, geoUri);
            StartActivity(mapIntent);
            */

            var geoUri = Android.Net.Uri.Parse("geo:42.374260,-71.120824");
            var mapIntent = new Intent(Intent.ActionView, geoUri);
            StartActivity(mapIntent);
        }
    }
}