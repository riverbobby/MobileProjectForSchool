using System;
using JustinTownleyMobile.Models;
using JustinTownleyMobile.ViewModels;
using JustinTownleyMobile.Services;
using System.Linq;
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
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new TermViewModel();
        }
        protected override bool OnBackButtonPressed()
        {
            DatabaseService.CurrentTermID = 0;
            return base.OnBackButtonPressed();
        }
        async void OnPreviousPageButtonClicked(object sender, EventArgs e)
        {
            DatabaseService.CurrentTermID = 0;
            await Navigation.PopAsync();
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DatabaseService.CurrentCourseID = (e.CurrentSelection.FirstOrDefault() as Course).CourseID;
            await Navigation.PushAsync(new CourseView());
        }

        private async void Add_New_Course_Button_Clicked(object sender, EventArgs e)
        {
            DatabaseService.CurrentCourseID = 0;
            await Navigation.PushAsync(new EditCourseView());
        }
        private async void Edit_Term_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditTermView());
        }
        private async void Delete_Term_Button_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("This will delete term \nAND all classes in term", "Cancel", "Delete");
            if (action == "Delete")
            {
                DatabaseService.RemoveTerm(DatabaseService.CurrentTermID);
                DatabaseService.CurrentTermID = 0;
                await Navigation.PopAsync();
            }
        }
    }
}