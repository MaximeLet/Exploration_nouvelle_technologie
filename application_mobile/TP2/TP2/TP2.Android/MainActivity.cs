using Android.App;
using Android.Content.PM;
using Android.OS;
using Prism.Unity;
using Microsoft.Practices.Unity;
using TP2.Core;
using Java.Interop;
using TP2.Core.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.Android;

namespace TP2.Android
{
    [Activity(Label = "TP2.Android", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        //private readonly ScanPageViewModel _scanPageViewModel;

        //public MainActivity(ScanPageViewModel scanPageViewModel)
        //{
        //    _scanPageViewModel = scanPageViewModel;
        //}

        //[Export("Test")]
        //public void TestAsync()
        //{
        //    string test = "";
        //    //await _scanPageViewModel.ElementScannedAsync(test);
        //}

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.tabs;
            ToolbarResource = Resource.Layout.toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {

        }
    }
}

