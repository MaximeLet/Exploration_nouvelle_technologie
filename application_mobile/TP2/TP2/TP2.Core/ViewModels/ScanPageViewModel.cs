using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Tp2.Externalization;
using TP2.Core.Repositories;
using TP2.Core.Repositories.Entities;
using TP2.Core.Services;
using TP2.Core.Validations;

namespace TP2.Core.ViewModels
{
    public class ScanPageViewModel : BindableBase, INavigatedAware
    {
        private readonly INavigationService _navigationService;
        private readonly IScannerService _scannerService;
        private readonly IRepository<Product> _productRepository;
        private ValidatableObject<bool> _elementScanned;
        private Product _product;
        public Product product
        {
            get { return _product; }
            set { SetProperty(ref _product, value); }
        }

        public ValidatableObject<bool> ConfirmButtonsAreAvailable
        {
            get => _elementScanned;
            set => SetProperty(ref _elementScanned, value);
        }


        public ScanPageViewModel(INavigationService navigationService, IScannerService scannerService, IRepository<Product> productRepository)
        {
            _navigationService = navigationService;
            _productRepository = productRepository;
            _scannerService = scannerService;
            _elementScanned = new ValidatableObject<bool>();
            _elementScanned.Value = false;
        }

        public ICommand CancelElementScannedCommand => new DelegateCommand(CancelElementScanned);

        private void CancelElementScanned()
        {
            _navigationService.NavigateAsync("app:///MainMasterDetailPage/NavigationPage/ScanPage");
        }

        public ICommand SaveElementScannedCommand => new DelegateCommand(SaveElementScannedAsync);

        private async void SaveElementScannedAsync()
        {
            if (_productRepository.IsProductAlreadyInInventory(_product))
            {
                await errorAsync(UiText.ScanErrorMessages.ProductIsAlreadyInInventory);
                return;
            }
            else
            {
                _productRepository.AddProductIntoInventory(_product);
                await _navigationService.NavigateAsync("app:///MainMasterDetailPage/NavigationPage/WelcomePage");
            }                        
        }

        public async Task ElementScannedAsync(string value)
        {
            int count = value.Split(';').Length - 1;
            if (_scannerService.ValidateElementScanned(count, value) != "")
            {
                await errorAsync(_scannerService.ValidateElementScanned(count, value));
                return;
            }

            string[] radioIdSplit = null;
            string radioId = "Non disponible ";

            string[] items = value.Split(';');
            string[] modalSplit = items[0].Split(':');
            string[] serialNumberSplit = items[1].Split(':');
            string[] dateOfProductionSplit = items[2].Split(':');
            if (value.Contains("RFE"))
            {
                radioIdSplit = items[3].Split(':');
                radioId = radioIdSplit[1];
            }

            product = new Product()
            {
                Modal = modalSplit[2],
                SerialNumber = serialNumberSplit[1],
                DateProduction = DateTime.Parse(dateOfProductionSplit[1]),
                RadioId = radioId
            };
            _elementScanned.Value = true;
        }

        private async Task errorAsync(string error)
        {
            await App.Current.MainPage.DisplayAlert("Erreur", error, "OK");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {

        }
    }
}
