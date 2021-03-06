﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Windows.Input;
using TP2.Core.Helpers;

namespace TP2.Core.ViewModels
{
    public class MainMasterDetailPageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private string _title;
        
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ICommand NavigateToWelcomePageCommand => new DelegateCommand(NavigateToWelcomePage);
        public ICommand NavigateToInventoryPageCommand => new DelegateCommand(NavigateToInventoryPage);
        public ICommand NavigateToQrCodeCreatorPageCommand => new DelegateCommand(NavigateToQrCodeCreatorPage);

        public MainMasterDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private void NavigateToQrCodeCreatorPage()
        {
            _navigationService.NavigateAsync(NavigationPaths.PathToGoQrCodeCreatorPage);
        }

        private void NavigateToInventoryPage()
        {
             _navigationService.NavigateAsync(NavigationPaths.PathToGoInventoryPage);
        }

        private void NavigateToWelcomePage()
        {
            _navigationService.NavigateAsync(NavigationPaths.PathToGoWelcomePage);
        }
        
        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
