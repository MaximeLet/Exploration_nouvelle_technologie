using NUnit.Framework;
using TP2.UITests.PageObjects;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Tp2.Externalization;

namespace TP2.UITests
{
    [TestFixture]
    public class TestHambugerMenu
    {
        private AndroidApp _app;
        private MainPage _mainPage;

        [SetUp]
        public void BeforeEachTest()
        {
            _app = ConfigureApp.Android
                .ApkFile(@"c:\temp\release.apk")
                .StartApp();
            
            _mainPage = new MainPage(_app);
        }

        [Test]
        public void MasterPage_PressOnIconOfHambugerMenu_MenuIsDisplayedMenu()
        {
            
            _mainPage.ClickOnHambugerMenuIcon();
            
            var idDisplayed = _mainPage.IsIdDisplayed(UiText.GlobalsId.InventoryMenu);
            Assert.IsTrue(idDisplayed); 
        }
    }
}

