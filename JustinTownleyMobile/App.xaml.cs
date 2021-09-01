using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JustinTownleyMobile.Views;

namespace JustinTownleyMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TermsView()) { BarBackgroundColor = Color.FromHex("#003057") };
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
