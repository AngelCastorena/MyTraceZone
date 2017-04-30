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
using Android.Provider;
using Android.Graphics;

namespace MyTraceZone
{
    [Activity(Label = "MTZ Camara")]
    public class ActivityCamera : Activity
    {
        ImageView mimageView;
        Button mbtnCamera;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Camara);

            mbtnCamera = FindViewById<Button>(Resource.Id.btnCamera);
            mimageView = FindViewById<ImageView>(Resource.Id.imageView);

            mbtnCamera.Click += mbtnCamera_Click;
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            Bitmap bitmap = (Bitmap)data.Extras.Get("data");
            mimageView.SetImageBitmap(bitmap);
            
        }

        private void mbtnCamera_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 0);
        }
    }
}