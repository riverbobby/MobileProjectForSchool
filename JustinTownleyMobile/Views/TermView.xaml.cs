using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JustinTownleyMobile.Models;
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
    public partial class TermView : ContentPage
    {
        public TermView()
        {
            InitializeComponent();
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DatabaseService.CurrentCourseID = (e.CurrentSelection.FirstOrDefault() as Course).CourseID;
            await Navigation.PushAsync(new CourseView());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            DatabaseService.CurrentCourseID = 0;
            await Navigation.PushAsync(new EditCourseView());
        }
    }
}