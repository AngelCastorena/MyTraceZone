using Android.App;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using System;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.Runtime;
using Android.Content;

namespace MyTraceZone
{
    [Activity(Label = "MyTraceZone", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        
        Button mButton;
        TextView mRegistro;
        EditText mtxtusuario;
        EditText mtxtcontraseña;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.Login);

            mButton = FindViewById<Button>(Resource.Id.btnconectar);
            mRegistro = FindViewById<TextView>(Resource.Id.textViewRegistrarse);
            mtxtusuario = FindViewById<EditText>(Resource.Id.txtusuario);
            mtxtcontraseña = FindViewById<EditText>(Resource.Id.txtcontraseña);
            mButton.Click += mButton_Click;
            mRegistro.Click += mRegistro_Click;
        }

        private void mRegistro_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ActivityRegistro));
            this.StartActivity(intent);
        }

        void mButton_Click(Object sender, EventArgs e)
        {
            if (mtxtusuario.Text == "unvato" & mtxtcontraseña.Text == "esamadre") 
            {
                mtxtusuario.Text = "";
                mtxtcontraseña.Text = "";
                Toast.MakeText(this, "Login Exitoso", ToastLength.Long).Show();
                Intent intent = new Intent(this, typeof(ActivityMenu));
                this.StartActivity(intent);
            }
            else
	        {
                Toast.MakeText(this, "Usuario o contraseña incorrecta", ToastLength.Long).Show();
            }
            
        }
    

    }
}

