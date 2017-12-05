using NUnit.Framework;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Core.Repositories;
using TP2.Core.Repositories.Entities;
using TP2.Core.Services;
using TP2.Core.ViewModels;
using TP2.UnitTests.Mock;

namespace TP2.UnitTests.ViewModels.TestNavigation
{
    [TestFixture]
    public class TestNavigationScanViewModel
    {
        private readonly INavigationService _mock = new NavigationServiceMock();
        private ScanPageViewModel _scanPageViewModel;
        private readonly IRepository<Product> _productRepository;
        private readonly IScannerService _mockScanService = new ScannerServiceMock();

        [SetUp]
        public void InitializationScanPageViewModel()
        {
            _scanPageViewModel = new ScanPageViewModel(_mock, _mockScanService, _productRepository);
        }

        [Test]
        public void NavigateToCancelElementScannedCommand_MustCallNavigationService_WhenMethodIsCall()
        {
            var mock = (NavigationServiceMock)_mock;

            _scanPageViewModel.CancelElementScannedCommand.Execute(null);

            Assert.IsTrue(mock.IsCall);
        }

        [Test]
        public void NavigateToCancelElementScannedCommand_MustCallNavigationServiceWithAGoodPath_WhenMethodIsCall()
        {
            var mock = (NavigationServiceMock)_mock;

            _scanPageViewModel.CancelElementScannedCommand.Execute(null);

            Assert.AreEqual(Core.Helpers.NavigationPaths.PathToGoScanPage, mock.Name);
        }
    }
}
