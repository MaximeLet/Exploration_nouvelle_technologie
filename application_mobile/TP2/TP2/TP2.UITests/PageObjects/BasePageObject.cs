using Xamarin.UITest;

namespace TP2.UITests.PageObjects
{
    public class BasePageObject
    {
        protected IApp App;

        public BasePageObject(IApp app)
        {
            App = app;
        }
    }
}