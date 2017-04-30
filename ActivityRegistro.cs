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
    [Activity(Label = "MTZ Registro")]
    public class ActivityRegistro : Activity
    {
        Button mbtnRegister;
        EditText mtxtName;
        EditText mtxtUserName;
        EditText mtxtEmail;
        EditText mtxtPass;
        EditText mtxtPassConfir;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SignUp);

            mbtnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            mtxtName = FindViewById<EditText>(Resource.Id.txtName);
            mtxtUserName = FindViewById<EditText>(Resource.Id.txtUserName);
            mtxtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            mtxtPass = FindViewById<EditText>(Resource.Id.txtPass);
            mtxtPassConfir = FindViewById<EditText>(Resource.Id.txtPassConfir);

            mbtnRegister.Click += mbtnRegister_Click;

        }

        private void mbtnRegister_Click(object sender, EventArgs e)
        {
            if (mtxtName != null & mtxtUserName != null & mtxtEmail != null & mtxtPass != null & mtxtPass == mtxtPassConfir)
            {
                Toast.MakeText(this, "Registro Exitoso", ToastLength.Long).Show();

            }
            else
            {
                if (mtxtPass != mtxtPassConfir)
                {
                    Toast.MakeText(this, "La contraseña no coincide", ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(this, "Complete todos los campos", ToastLength.Long).Show();
                    
                }
            }
        }
    }
}