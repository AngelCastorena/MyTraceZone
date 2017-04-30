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
using System;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.Runtime;
using Android.Content;

namespace MyTraceZone
{
    [Activity(Label = "MyTraceZone")]
    public class ActivityLogin : Activity, IOnMapReadyCallback, ILocationListener
    {
        GoogleMap map;
        Spinner spinner;
        LocationManager locationManager;
        String provider;


        public void OnLocationChanged(Location location)
        {
            Double lat, lng;
            lat = location.Latitude;
            lng = location.Longitude;
            MarkerOptions makerOptions = new MarkerOptions();
            makerOptions.SetPosition(new LatLng(lat, lng));
            makerOptions.SetTitle("My Position");
            map.AddMarker(makerOptions);

            //Move Camera
            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(new LatLng(lat, lng));
            CameraPosition cameraPosition = builder.Build();
            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
            map.MoveCamera(cameraUpdate);
            

        }

        public void OnMapReady(GoogleMap googleMap)
        {
            map = googleMap;
            
            //opcional
            googleMap.UiSettings.ZoomControlsEnabled = true;
            googleMap.UiSettings.CompassEnabled = true;
            googleMap.MoveCamera(CameraUpdateFactory.ZoomIn());
            
        }

        protected override void OnResume()
        {
            base.OnResume();
            locationManager.RequestLocationUpdates(provider, 400, 1, this);
        }



        protected override void OnPause()
        {
            base.OnPause();
            locationManager.RemoveUpdates(this);
        }

        public void OnProviderDisabled(string provider)
        {
            //  throw new NotImplementedException();
        }

        public void OnProviderEnabled(string provider)
        {
            //throw new NotImplementedException();
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            // throw new NotImplementedException();
        }


       


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
            spinner = FindViewById<Spinner>(Resource.Id.spinner);
            MapFragment mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this);

            locationManager = (LocationManager)GetSystemService(Context.LocationService);
            provider = locationManager.GetBestProvider(new Criteria(), false);

            Location location = locationManager.GetLastKnownLocation(provider);
            if (location == null)
            {
                System.Diagnostics.Debug.WriteLine("No Location");
            }

            spinner.ItemSelected += Spinner_ItemSelected;
        }

        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            switch (e.Position)
            {
                case 0:
                    map.MapType = GoogleMap.MapTypeHybrid;
                    break;
                case 1:
                    map.MapType = GoogleMap.MapTypeNone;
                    break;
                case 2:
                    map.MapType = GoogleMap.MapTypeNormal;
                    break;
                case 3:
                    map.MapType = GoogleMap.MapTypeSatellite;
                    break;
                case 4:
                    map.MapType = GoogleMap.MapTypeTerrain;
                    break;
                default:
                    map.MapType = GoogleMap.MapTypeNone;
                    break;
            }
        }
    }
}