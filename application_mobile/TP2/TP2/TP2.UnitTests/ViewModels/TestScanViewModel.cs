using NUnit.Framework;
using Prism.Navigation;
using System.Globalization;
using System.Threading.Tasks;
using TP2.Core.Repositories;
using TP2.Core.Repositories.Entities;
using TP2.Core.Services;
using TP2.Core.ViewModels;
using TP2.UnitTests.Mock;

namespace TP2.UnitTests.ViewModels
{
    [TestFixture]
    public class TestScanViewModel
    {
        private readonly INavigationService _mockNavigationService = new NavigationServiceMock();
        private ScanPageViewModel _scanPageViewModel;
        private readonly IRepository<Product> _productRepository;
        private IScannerService _scannerService = new ScannerServiceMock();

        [SetUp]
        public void InitializationScanPageViewModel()
        {

            _scanPageViewModel = new ScanPageViewModel(_mockNavigationService, _scannerService, _productRepository);
        }

        [Test]
        public void ScanCommandWithMissingElements_MustNotChangeTheProductInitialValue_WhenMethodIsCallAsync()
        {
            string value = "errorMissingElement";
            Product productBeforeBeingScanned = _scanPageViewModel.product;
            _scanPageViewModel.ElementScannedAsync(value);
            Product productAfterBeingScanned = _scanPageViewModel.product;
            Assert.AreEqual(productBeforeBeingScanned, productAfterBeingScanned);
        }

        [Test]
        public void ScanCommandWithoutAModalElement_MustNotChangeTheProductInitialValue_WhenMethodIsCallAsync()
        {
            string value = "magikA:ErrorHere:REDBV1;SER:R200523;FABD:2017-01-28;RFE:0A.1C.CB";
            Product productBeforeBeingScanned = _scanPageViewModel.product;
            _scanPageViewModel.ElementScannedAsync(value);
            Product productAfterBeingScanned = _scanPageViewModel.product;
            Assert.AreEqual(productBeforeBeingScanned, productAfterBeingScanned);
        }

        [Test]
        public void ScanCommandWithoutASerialNumber_MustNotChangeTheProductInitialValue_WhenMethodIsCallAsync()
        {
            string value = "magikA:M:REDBV1;ErrorHere:R200523;FABD:2017-01-28;RFE:0A.1C.CB";
            Product productBeforeBeingScanned = _scanPageViewModel.product;
            _scanPageViewModel.ElementScannedAsync(value);
            Product productAfterBeingScanned = _scanPageViewModel.product;
            Assert.AreEqual(productBeforeBeingScanned, productAfterBeingScanned);
        }

        [Test]
        public void ScanCommandWithoutADateOfProduction_MustNotChangeTheProductInitialValue_WhenMethodIsCallAsync()
        {
            string value = "magikA:M:REDBV1;SER:R200523;ErrorHere:2017-01-28;RFE:0A.1C.CB";
            Product productBeforeBeingScanned = _scanPageViewModel.product;
            _scanPageViewModel.ElementScannedAsync(value);
            Product productAfterBeingScanned = _scanPageViewModel.product;
            Assert.AreEqual(productBeforeBeingScanned, productAfterBeingScanned);
        }

        [Test]
        public void ScanCommandWithAllTheRightElements_MustChangeTheProductInitialValue_WhenMethodIsCallAsync()
        {
            string value = "magikA:M:REDBV1;SER:R200523;FABD:2017-01-28;RFE:0A.1C.CB";
            string EXPECTED_MODAL_VALUE = "REDBV1";
            string EXPECTED_SERIAL_NUMBER = "R200523";
            string EXPECTED_PRODUCTION_DATE = "2017-01-28";

            _scanPageViewModel.ElementScannedAsync(value);
            Product product = _scanPageViewModel.product;
            Assert.AreEqual(EXPECTED_MODAL_VALUE, product.Modal);
            Assert.AreEqual(EXPECTED_SERIAL_NUMBER, product.SerialNumber);
            Assert.AreEqual(EXPECTED_PRODUCTION_DATE, product.DateProduction.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
        }
    }
}
