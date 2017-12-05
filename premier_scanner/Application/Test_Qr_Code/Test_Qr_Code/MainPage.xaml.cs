using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace Test_Qr_Code
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var scanPage = new ZXingScannerPage ();

            scanPage.OnScanResult += (result) => {
                // Stop scanning
                scanPage.IsScanning = false;

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread (() => {
                    Navigation.PopAsync ();        
                    DisplayAlert("Scanned Barcode", result.Text, "OK");
                });
            };

            // Navigate to our scanner page
            await Navigation.PushAsync (scanPage);
        }
    }
}
