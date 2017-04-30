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

namespace MyTraceZone
{
    [Activity(Label = "MTZ Menu")]
    public class ActivityMenu : Activity
    {
        Button mbtncamara;
        Button mbtnmapa;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Menu);

            mbtncamara = FindViewById<Button>(Resource.Id.btncamara);
            mbtnmapa = FindViewById<Button>(Resource.Id.btnmapa);

            mbtnmapa.Click += mbtnmapa_Click;
            mbtncamara.Click += mbtncamara_Click;
        }

        private void mbtncamara_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Aun no esta completo", ToastLength.Long).Show();
            Intent intent = new Intent(this, typeof(ActivityCamera));
            this.StartActivity(intent);
        }

        private void mbtnmapa_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Entrando al mapa", ToastLength.Long).Show();
            Intent intent = new Intent(this, typeof(ActivityLogin));
            this.StartActivity(intent);
        }
    }
}