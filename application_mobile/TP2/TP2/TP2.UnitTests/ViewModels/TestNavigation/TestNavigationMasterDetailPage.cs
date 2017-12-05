using NUnit.Framework;
using Prism.Navigation;
using TP2.Core.Helpers;
using TP2.Core.ViewModels;
using TP2.UnitTests.Mock;

namespace TP2.UnitTests.ViewModels.TestNavigation
{
    [TestFixture]
    public class TestNavigationMasterDetailPage
    {
        private readonly INavigationService _mock = new NavigationServiceMock();
        private MainMasterDetailPageViewModel _mainMaster;
        
        [SetUp]
        public void InitializationMainMasterDetailPageViewModel()
        {
            _mainMaster = new MainMasterDetailPageViewModel(_mock);
        }
        
        [Test]
        public void NavigateToWelcomePageCommand_MustCallNavigationService_WhenMethodIsCall()
        {
            var mock = (NavigationServiceMock) _mock;

          _mainMaster.NavigateToWelcomePageCommand.Execute(null);

            Assert.IsTrue(mock.IsCall);
        }
        
        [Test]
        public void NavigateToWelcomePageCommand_MustCallNavigationServiceWithAGoodPath_WhenMethodIsCall()
        {
            var mock = (NavigationServiceMock) _mock;

            _mainMaster.NavigateToWelcomePageCommand.Execute(null);

            Assert.AreEqual(NavigationPaths.PathToGoWelcomePage, mock.Name);
        }
        
        [Test]
        public void NavigateToInventoryPageCommand_MustCallNavigationService_WhenMethodIsCall()
        {
            var mock = (NavigationServiceMock) _mock;

            _mainMaster.NavigateToInventoryPageCommand.Execute(null);

            Assert.IsTrue(mock.IsCall);
        }
        
        [Test]
        public void NavigateToInventoryPageCommand_MustCallNavigationServiceWithAGoodPath_WhenMethodIsCall()
        {
            var mock = (NavigationServiceMock) _mock;

            _mainMaster.NavigateToInventoryPageCommand.Execute(null);

            Assert.AreEqual(NavigationPaths.PathToGoInventoryPage, mock.Name);
        }
        
        [Test]
        public void NavigateToQrCodeCreatorPageCommand_MustCallNavigationService_WhenMethodIsCall()
        {
            var mock = (NavigationServiceMock) _mock;

            _mainMaster.NavigateToQrCodeCreatorPageCommand.Execute(null);

            Assert.IsTrue(mock.IsCall);
        }
        
        [Test]
        public void NavigateToQrCodeCreatorPageCommand_MustCallNavigationServiceWithAGoodPath_WhenMethodIsCall()
        {
            var mock = (NavigationServiceMock) _mock;
            _mainMaster.NavigateToQrCodeCreatorPageCommand.Execute(null);

            Assert.AreEqual(NavigationPaths.PathToGoQrCodeCreatorPage, mock.Name);
        }
    }
}