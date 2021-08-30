﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustinTownleyMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JustinTownleyMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermView : ContentPage
    {
        public TermView()
        {
            InitializeComponent();
            BindingContext = new TermViewModel();
        }
    }
}