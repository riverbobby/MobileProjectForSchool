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

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void Button_Pressed(object sender, EventArgs e)
        {

        }

        private void Button_Pressed_1(object sender, EventArgs e)
        {

        }
    }
}