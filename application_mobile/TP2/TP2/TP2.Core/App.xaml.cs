using System;
using Microsoft.Practices.Unity;
using Prism.Unity;
using SQLite;
using TP2.Core.Helpers;
using TP2.Core.Repositories;
using TP2.Core.Repositories.Entities;
using TP2.Core.Services;
using TP2.Core.Views;
using Xamarin.Forms;

namespace TP2.Core
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync("MainMasterDetailPage/NavigationPage/WelcomePage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<WelcomePage>();
            Container.RegisterTypeForNavigation<ScanPage>();
            Container.RegisterTypeForNavigation<MainMasterDetailPage>();
            Container.RegisterTypeForNavigation<InventoryPage>();
            Container.RegisterTypeForNavigation<QrCodeCreatorPage>();
            Container.RegisterTypeForNavigation<DisplayNewQrCodePage>();

            var databasePath = DependencyService.Get<IFileHelper>().GetLocalFilePath("Tp2Database.db3");
            var database = new SQLiteConnection(databasePath);

            Container.RegisterType<IScannerService, ScannerService>(
                new ContainerControlledLifetimeManager(),
                new InjectionConstructor());

            Container.RegisterType<IQrCodeService, QrCodeService>(
               new ContainerControlledLifetimeManager(),
               new InjectionConstructor());

            Container.RegisterType<IRepository<Product>, SqLiteRepository<Product>>(
                new ContainerControlledLifetimeManager(),
                new InjectionConstructor(database));
        }
    }
}
