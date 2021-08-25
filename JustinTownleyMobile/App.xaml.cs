﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JustinTownleyMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.EditTermPage());
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
