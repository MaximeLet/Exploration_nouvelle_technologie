using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace TP2.Core.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScanPage : ContentPage
	{
        private ScanPageViewModel _scanPageViewModel;
        public ScanPage ()
		{
                InitializeComponent ();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _scanPageViewModel = (ScanPageViewModel)BindingContext;
        }

        private async Task Button_Clicked(object sender, EventArgs e)
        {
            var scanPage = new ZXingScannerPage();

            scanPage.OnScanResult += (result) =>
            {
                // Stop scanning
                scanPage.IsScanning = false;

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    //DisplayAlert("Scanned Barcode", result.Text, "OK");
                    await _scanPageViewModel.ElementScannedAsync(result.Text);
                });
            };

            // Navigate to our scanner page
            await Navigation.PushAsync(scanPage);
        }

        private async Task Button_Clicked_temporaireAsync()
        {
            string value = "magikA:M:REDBV1;SER:R200523;FABD:2017-01-28;RFE:0A.1C.CB";
            await _scanPageViewModel.ElementScannedAsync(value);
        }
    }
}