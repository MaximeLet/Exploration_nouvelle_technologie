using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prism.Navigation;

namespace TP2.UnitTests.Mock
{
    public class NavigationServiceMock : INavigationService
    {
        public bool IsCall;
        public string Name = "";
        public List<string> KeysInParam = new List<string>();
        
        public Task<bool> GoBackAsync(NavigationParameters parameters = null, bool? useModalNavigation = null, bool animated = true)
        {
            throw new NotImplementedException();
        }

        public Task NavigateAsync(Uri uri, NavigationParameters parameters = null, bool? useModalNavigation = null,
            bool animated = true)
        {
            throw new NotImplementedException();
        }

        public Task NavigateAsync(string name, NavigationParameters parameters = null, bool? useModalNavigation = null,
            bool animated = true)
        {
            IsCall = true;
            Name = name;
            if (parameters != null)
            {
                foreach (var parametersKey in parameters.Keys)
                    KeysInParam.Add(parametersKey);
            }
            return null;
        }
    }
}