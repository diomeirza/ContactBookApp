using ContactBookApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBookApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ContactMainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
