using NUnit.Framework;
using Tp2.Externalization;
using TP2.UITests.PageObjects;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace TP2.UITests
{
    [TestFixture]
    public class TestDisplayQrCodePage
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
        public void QrCodeCreatorPage_EnterAGoodValue_QrCodeImageWasDisplayed()
        {
            _mainPage.GoToQrCodeCreatorPage();
            _mainPage.AddTextInEntry(UiText.GlobalsId.ModelEntry, "LEVSND");
            _mainPage.AddTextInEntry(UiText.GlobalsId.SerialNumberEntry, "LEV0209");

            _mainPage.TapOnButton(UiText.GlobalsId.ButtonInQrCodePageCreator);
            
            var idDisplayed = _mainPage.IsIdDisplayed(UiText.GlobalsId.IdQrCodeImage);
            Assert.IsTrue(idDisplayed); 
        }
    }
}