using Xamarin.UITest;

namespace TP2.UITests.Helpers
{
    public class UiTestHelper
    {
        public static bool IsTextDisplayed(IApp app, string id)
        {
            try
            {
                app.WaitForElement(id);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}