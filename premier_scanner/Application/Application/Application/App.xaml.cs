using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Views;
using Xamarin.Forms;

namespace Application
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MasterDetailPage()
            {
                Master = new MasterPage() { Title = "Main Page" },
                Detail = new NavigationPage(new MainPage())
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
