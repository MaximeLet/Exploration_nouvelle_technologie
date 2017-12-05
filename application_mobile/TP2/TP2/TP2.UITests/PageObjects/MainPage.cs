using TP2.UITests.Helpers;
using Xamarin.UITest;
using Tp2.Externalization;


namespace TP2.UITests.PageObjects
{
    public class MainPage : BasePageObject
    {
        public MainPage(IApp app) : base(app)
        {
        }

        public void ClickOnHambugerMenuIcon()
        {
           App.Tap("OK");
        }

        public bool? IsIdDisplayed(string elementSearch)
        {
            return UiTestHelper.IsTextDisplayed(App, elementSearch);
        }

        public void GoToQrCodeCreatorPage()
        {
            ClickOnHambugerMenuIcon();
            App.Tap(UiText.GlobalsId.QrCodeCreatorMenu);
        }

        public void GoToScanPage()
        {
            App.Tap(UiText.GlobalsId.ScanPageButton);
        }

        public void AddTextInEntry(string entry, string message)
        {
            App.WaitForElement(entry);
            App.ClearText(entry);
            App.EnterText(entry, message);
        }

        public void TapOnButton(string buttonId)
        {
            App.Tap(buttonId);
        }
    }
}