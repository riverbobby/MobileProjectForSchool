using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JustinTownleyMobile.ViewModels;
using JustinTownleyMobile.Services;
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
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            DatabaseService.CurrentTermID = 0;
            await Navigation.PushAsync(new EditTermView());
        }
    }
}