using System.Collections.Generic;
using NUnit.Framework;
using Prism.Navigation;
using TP2.Core.Helpers;
using TP2.Core.ViewModels;
using TP2.UnitTests.Mock;

namespace TP2.UnitTests.ViewModels.TestNavigation
{
    
    [TestFixture]
    public class TestNavigationQrCodeCreatorViewModel
    {
        private static readonly List<string> KeysInParam = new List<string>{ "model", "serialNumber", "radioId"};
        private readonly INavigationService _mock = new NavigationServiceMock();
        private QrCodeCreatorPageViewModel _codeCreatorPageViewModel;
        
        [SetUp]
        public void InitializationMainMasterDetailPageViewModel()
        {
            _codeCreatorPageViewModel = new QrCodeCreatorPageViewModel(_mock);
        }
        
        [Test]
        public void NavigateToNavigateToDisplayNewQrCodeCommand_MustCallNavigationService_WhenMethodIsCall()
        {
            var mock = (NavigationServiceMock) _mock;

            _codeCreatorPageViewModel.NavigateToDisplayNewQrCodeCommand.Execute(null);

            Assert.IsTrue(mock.IsCall);
        }
        
        [Test]
        public void NavigateToToNavigateToDisplayNewQrCodeCommand_MustCallNavigationServiceWithAGoodPath_WhenMethodIsCall()
        {
            var mock = (NavigationServiceMock) _mock;

            _codeCreatorPageViewModel.NavigateToDisplayNewQrCodeCommand.Execute(null);

            Assert.AreEqual(NavigationPaths.PathToGoDisplayNewQrCodePage, mock.Name);
        }
        
        [Test]
        public void NavigateToToNavigateToDisplayNewQrCodeCommand_MustCallNavigationServiceWithFourParameters_WhenMethodIsCall()
        {
            var mock = (NavigationServiceMock) _mock;

            _codeCreatorPageViewModel.NavigateToDisplayNewQrCodeCommand.Execute(null);

            Assert.IsTrue(ParametersContainsAllKeyValue(mock.KeysInParam));
        }

        private bool ParametersContainsAllKeyValue(IReadOnlyCollection<string> keysInParam)
        {
            if (keysInParam == null)
            {
                return false;
            }
            foreach (var parameterKey in keysInParam)
            {
                if (!KeysInParam.Contains(parameterKey))
                {
                    return false;
                }
            }
            return true;
        }
    }
}