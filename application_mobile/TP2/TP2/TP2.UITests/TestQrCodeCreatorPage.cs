using NUnit.Framework;
using Tp2.Externalization;
using TP2.UITests.PageObjects;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace TP2.UITests
{
    [TestFixture]
    public class TestQrCodeCreatorPage
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
        public void QrCodeCreatorPage_EnterANotValidValue_ErrorIsDisplayed()
        {
            _mainPage.GoToQrCodeCreatorPage();

            _mainPage.AddTextInEntry(UiText.GlobalsId.ModelEntry, "Bad model entry!");

            var idDisplayed = _mainPage.IsIdDisplayed(UiText.ModelErrorMessages.LengthNotValid);
            Assert.IsTrue(idDisplayed); 
        }
        
        [Test]
        public void QrCodeCreatorPage_EnterANotValidValue_ButtonStayIncativate()
        {
            _mainPage.GoToQrCodeCreatorPage();
            _mainPage.AddTextInEntry(UiText.GlobalsId.ModelEntry, "Bad model entry!");


            _mainPage.TapOnButton(UiText.GlobalsId.ButtonInQrCodePageCreator);
            
            var idDisplayed = _mainPage.IsIdDisplayed(UiText.GlobalsId.ModelEntry);
            Assert.IsTrue(idDisplayed); 
        }
        
    }
}