using NUnit.Framework;
using System;
using Tp2.Externalization;
using TP2.UITests.PageObjects;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Utils;

namespace TP2.UITests
{
    [TestFixture]
    public class TestScanPage
    {
        private AndroidApp _app;
        private MainPage _mainPage;

        [SetUp]
        public void BeforeEachTest()
        {
            _app = ConfigureApp.Android
                .ApkFile(@"c:\temp\release.apk")
                //.WaitTimes(new WaitTimes())
                .StartApp();

            _mainPage = new MainPage(_app);
        }

        //public class WaitTimes : IWaitTimes
        //{
        //    public TimeSpan GestureWaitTimeout
        //    {
        //        get { return TimeSpan.FromMinutes(3); }
        //    }
        //    public TimeSpan WaitForTimeout
        //    {
        //        get { return TimeSpan.FromMinutes(3); }
        //    }

        //    public TimeSpan GestureCompletionTimeout => throw new NotImplementedException();
        //}

        [Test]
        public void ScanPage_ScanAResultWithMissingElements_ErrorElementMissingIsDisplayed()
        {
            _mainPage.GoToScanPage();
            _mainPage.TapOnButton(UiText.GlobalsId.ScannerButton);
            //_app.Repl();

            var idDisplayed = _mainPage.IsIdDisplayed("zxingDefaultOverlay");
            Assert.IsTrue(idDisplayed);
        }

        [Test]
        public void test()
        {
            _mainPage.GoToScanPage();
            //_app.WaitForElement(c => c.Marked("button1"));
            _app.Invoke("Test");
            //_app.Repl();

            var idDisplayed = _mainPage.IsIdDisplayed("zxingDefaultOverlay");
            Assert.IsTrue(idDisplayed);
        }
    }
}
