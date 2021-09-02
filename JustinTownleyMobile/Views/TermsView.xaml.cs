using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JustinTownleyMobile.ViewModels;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JustinTownleyMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermsView : ContentPage
    {
        public TermsView()
        {
            InitializeComponent();

            BindingContext = new TermsViewModel();
        }
    }
}