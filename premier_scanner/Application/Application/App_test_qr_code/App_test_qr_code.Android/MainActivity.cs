using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Prism.Unity;
using Android.OS;
using Microsoft.Practices.Unity;
using Prism;

namespace App_test_qr_code.Droid
{
    [Activity(Label = "App_test_qr_code", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;


            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            ZXing.Net.Mobile.Forms.Android.Platform.Init();

            LoadApplication(new App(new AndroidInitializer()));
        }
        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            global::ZXing.Net.Mobile.Forms.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        
        public class AndroidInitializer : IPlatformInitializer
        {
            public void RegisterTypes(IUnityContainer container)
            {

            }

            
        }
    }
}

