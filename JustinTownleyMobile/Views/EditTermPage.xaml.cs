﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JustinTownleyMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditTermPage : ContentPage
    {
        public EditTermPage()
        {
            InitializeComponent();

            if (Globals.CurrentTermID < 0)
            {
                BindingContext = Globals.CurrentTerm;
            }
            else
            {
                BindingContext = new Term();
            }
        }
    }
}