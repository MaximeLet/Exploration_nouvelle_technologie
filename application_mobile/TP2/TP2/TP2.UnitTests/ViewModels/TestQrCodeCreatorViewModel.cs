using NUnit.Framework;
using Prism.Navigation;
using Tp2.Externalization;
using TP2.Core.ViewModels;
using TP2.UnitTests.Mock;

namespace TP2.UnitTests.ViewModels
{
    [TestFixture]
    public class TestQrCodeCreatorViewModel
    {
        private readonly INavigationService _mockNavigationService = new NavigationServiceMock();
        private QrCodeCreatorPageViewModel _codeCreatorPageViewModel;
        
        [SetUp]
        public void InitializationQrCodeCreatorPageViewModel()
        {
            _codeCreatorPageViewModel = new QrCodeCreatorPageViewModel(_mockNavigationService);
        }
        
        [Test]
        public void CanExecuteNavigateToDisplayNewQrCode_WhenModelIsNull_ReturnFalse()
        {
            _codeCreatorPageViewModel.Model.Value = null;

            var actualAswer = _codeCreatorPageViewModel.NavigateToDisplayNewQrCodeCommand.CanExecute(null);

            Assert.IsFalse(actualAswer);
        }
        
        [Test]
        public void CanExecuteNavigateToDisplayNewQrCode_WhenSerialNumberIsNull_ReturnFalse()
        {
            _codeCreatorPageViewModel.SerialNumber.Value = null;

            var actualAswer = _codeCreatorPageViewModel.NavigateToDisplayNewQrCodeCommand.CanExecute(null);

            Assert.IsFalse(actualAswer);
        }
        
        [Test]
        public void CanExecuteNavigateToDisplayNewQrCode_WhenSerialNumberAndModelAreNull_ReturnFalse()
        {
            _codeCreatorPageViewModel.SerialNumber.Value = null;
            _codeCreatorPageViewModel.Model.Value = null;

            var actualAswer = _codeCreatorPageViewModel.NavigateToDisplayNewQrCodeCommand.CanExecute(null);

            Assert.IsFalse(actualAswer);
        }
        
        [Test]
        public void CanExecuteNavigateToDisplayNewQrCode_WhenModelIsNotValid_ReturnFalse()
        {
            _codeCreatorPageViewModel.Model.IsValid = false;

            var actualAswer = _codeCreatorPageViewModel.NavigateToDisplayNewQrCodeCommand.CanExecute(null);

            Assert.IsFalse(actualAswer);
        }
        
        [Test]
        public void CanExecuteNavigateToDisplayNewQrCode_WhenSerialNumberIsNotValid_ReturnFalse()
        {
            _codeCreatorPageViewModel.SerialNumber.Value = null;

            var actualAswer = _codeCreatorPageViewModel.NavigateToDisplayNewQrCodeCommand.CanExecute(null);

            Assert.IsFalse(actualAswer);
        }
        
        [Test]
        public void CanExecuteNavigateToDisplayNewQrCode_WhenSerialNumberAndModelAreNotNullAndAreNotContainsError_ReturnTrue()
        {
            _codeCreatorPageViewModel.SerialNumber.Value = "RED!";
            _codeCreatorPageViewModel.Model.Value = "R500001";

            var actualAswer = _codeCreatorPageViewModel.NavigateToDisplayNewQrCodeCommand.CanExecute(null);

            Assert.IsTrue(actualAswer);
        }
        
        [Test]
        public void CanExecuteNavigateToDisplayNewQrCode_WhenRadioIdIsNull_RadioIdWillBeSetWithDefaultValue()
        {
            _codeCreatorPageViewModel.SerialNumber.Value = "RED!";
            _codeCreatorPageViewModel.Model.Value = "R500001";
            _codeCreatorPageViewModel.RadioId = "";

            _codeCreatorPageViewModel.NavigateToDisplayNewQrCodeCommand.CanExecute(null);
            var actualRadioIdValue = _codeCreatorPageViewModel.RadioId;

            Assert.AreEqual(UiText.RadioIdMessages.MsgIfNoRadioId, actualRadioIdValue);
        }
        
        [Test]
        public void CanExecuteNavigateToDisplayNewQrCode_WhenRadioIdIsNotNull_RadioIdWillBeKeepHisValue()
        {
            _codeCreatorPageViewModel.SerialNumber.Value = "RED!";
            _codeCreatorPageViewModel.Model.Value = "R500001";
            const string expectedValue = "123";
            _codeCreatorPageViewModel.RadioId = expectedValue;

            _codeCreatorPageViewModel.NavigateToDisplayNewQrCodeCommand.CanExecute(null);
            var actualRadioIdValue = _codeCreatorPageViewModel.RadioId;

            Assert.AreEqual(expectedValue, actualRadioIdValue);
        }
    }
}