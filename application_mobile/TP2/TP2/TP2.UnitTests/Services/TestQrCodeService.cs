using System;
using System.Threading.Tasks;
using NUnit.Framework;
using TP2.Core.Services;
using TP2.UnitTests.Factory;

namespace TP2.UnitTests.Services
{
    [TestFixture]
    public class TestQrCodeService
    {
        private QrCodeService _qrCodeService;
        private ProductBuilder _productBuilder;

        public TestQrCodeService()
        {
            Mock.MockForms.Init();
        }

        [SetUp]
        public void InitializationQrCodeService()
        {
            _qrCodeService = new QrCodeService();
            _productBuilder = new ProductBuilder();
        }

        [Test]
        public void GetQrCode_WhenItWasCall_ShouldBeReturnPathContainsPng()
        {
            var product = _productBuilder.GenerateProduct();
            var pathIsGood = false;
            
            Task<string> task = _qrCodeService.GetQrCode(product.Modal, product.SerialNumber, product.RadioId,
                product.DateProduction);
            task.Wait(new TimeSpan(0,0,2));
            
            if (task.Result.Contains(QrCodeService.QrCodeName))
            {
                pathIsGood = true;
            }
            Assert.IsTrue(pathIsGood);
        }
    }
}