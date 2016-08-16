using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using Android.Views.InputMethods;
using System.Text;

//enter you google map key in manifestfile


namespace RideShare2
{
    [Activity(Label = "Driver Location", MainLauncher = true)]
    public class DriverHomeActivity : Activity
    {
        const string  strAutoCompleteGoogleApi="https://maps.googleapis.com/maps/api/place/autocomplete/json?input=";
  //browser key for place webservice
  const string strGoogleApiKey="*****yCaRfEwrLeUvdADPn_R9WQ_WrP3jB*****";
  const string strGeoCodingUrl="https://maps.googleapis.com/maps/api/geocode/json";
  AutoCompleteTextView txtSearch;
  MapFragment mapFrag;
  GoogleMap map;
  ArrayAdapter adapter=null;  
  GoogleMapPlaceClass objMapClass;
  GeoCodeJSONClass objGeoCodeJSONClass;
  string autoCompleteOptions;
  string[] strPredictiveText;
  int index = 0;

 protected override void OnCreate (Bundle savedInstanceState)
  {
  base.OnCreate (savedInstanceState); 
  SetContentView ( Resource.Layout.Main );
//Each Tag <,> enclosed with single quote to avoid HTML interpretation,Pl aviod it
  txtSearch = FindViewById'<'autocompletetextview'>'( Resource.Id.txtTextSearch );  
  txtSearch.ItemClick += AutoCompleteOption_Click;
  txtSearch.Hint = "Enter source  "; 
  mapFrag = (MapFragment) FragmentManager.FindFragmentById(Resource.Id.map);
  map = mapFrag.Map; 
  map.MapType = GoogleMap.MapTypeNormal; 
  map.MyLocationEnabled = true;

  txtSearch.TextChanged += async  delegate(object sender, Android.Text.TextChangedEventArgs e)
   {  
  try
  {
 autoCompleteOptions=await fnDownloadString(strAutoCompleteGoogleApi+txtSearch.Text+"&key="+strGoogleApiKey);

  if ( autoCompleteOptions == "Exception" )
  {
 Toast.MakeText ( this , "Unable to connect to server!!!" , ToastLength.Short ).Show ();
   return;
  } 
    objMapClass = JsonConvert.DeserializeObject'<'googlemapplaceclass'>' (autoCompleteOptions);
    strPredictiveText= new string[objMapClass.predictions.Count];
    index = 0;
    foreach(Prediction objPred  in objMapClass.predictions)
   {
   strPredictiveText[index] = objPred.description;
   index++; 
   } 
   adapter = new ArrayAdapter'<'string'>' ( this ,Android.Resource.Layout.SimpleDropDownItem1Line, strPredictiveText ); 
 txtSearch.Adapter = adapter; 
     }
 catch
     {
Toast.MakeText ( this , "Unable to process at this moment!!!" , ToastLength.Short ).Show ();
     }

     };  

 }
async void  AutoCompleteOption_Click(object sender,AdapterView.ItemClickEventArgs e)
 { 
   //to soft keyboard hide
   InputMethodManager inputManager = (InputMethodManager)this.GetSystemService (Context.InputMethodService);
   inputManager.HideSoftInputFromWindow (txtSearch.WindowToken, HideSoftInputFlags.NotAlways);
   map.Clear ();
   if(txtSearch.Text!=string.Empty)
   { 
    var sb = new StringBuilder();
    sb.Append(strGeoCodingUrl);
    sb.Append("?address=").Append(txtSearch.Text);
    string strResult=await fnDownloadString(sb.ToString()); 
    if ( strResult == "Exception" )
    {
     Toast.MakeText ( this , "Unable to connect to server!!!" , ToastLength.Short ).Show ();

    }
//below used single quote to avoid html interpretation
    objGeoCodeJSONClass= JsonConvert.DeserializeObject'<'geocodejsonclass'>' (strResult);  
    LatLng Position=new LatLng(objGeoCodeJSONClass.results[0].geometry.location.lat,objGeoCodeJSONClass.results[0].geometry.location.lng); 
    updateCameraPosition (Position);
    MarkOnMap("MyLocation",Position); 
   }

  } 
  void MarkOnMap(string title,LatLng pos )
  { 
   RunOnUiThread ( () =>
   {
    var marker = new MarkerOptions ();
    marker.SetTitle ( title ); 
    marker.SetPosition ( pos );
    map.AddMarker ( marker ); 
   } );

  } 
  void updateCameraPosition(LatLng pos)
  {
   CameraPosition.Builder builder = CameraPosition.InvokeBuilder(); 
   builder.Target(pos);
   builder.Zoom(14);
   builder.Bearing(45);
   builder.Tilt(90);
   CameraPosition cameraPosition = builder.Build(); 
   CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition); 
   map.AnimateCamera(cameraUpdate);
  }
  async Task<string> fnDownloadString(string strUri)
  { 
   WebClient webclient = new WebClient ();
   string strResultData;
   try
   {
    strResultData= await webclient.DownloadStringTaskAsync (new Uri(strUri));
    Console.WriteLine(strResultData);
   }
   catch
   {
    strResultData = "Exception";
    RunOnUiThread ( () =>
    { 
     Toast.MakeText ( this , "Unable to connect to server!!!" , ToastLength.Short ).Show ();
    } );
   }
   finally
   {
    webclient.Dispose ();
    webclient = null; 
   }

   return strResultData;
  }

 }
}
</string>
