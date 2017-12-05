using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Windows.Input;

namespace TP2.Core.ViewModels
{
    public class WelcomePageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;

        public WelcomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand ScanButtonClickedCommand => new DelegateCommand(ScanButtonClicked);

        private void ScanButtonClicked()
        {
            _navigationService.NavigateAsync("app:///MainMasterDetailPage/NavigationPage/ScanPage");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }
    }
}
