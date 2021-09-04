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
using Xamarin.Essentials;

namespace JustinTownleyMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseView : ContentPage
    {
        public CourseView()
        {
            InitializeComponent();
        }
        private async void Share_Button_Clicked(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = CourseViewModel.Course.Notes,
                Title = $"{CourseViewModel.Course.CourseName} Notes"
            });
        }
        private void Update_OA_Button_Clicked(object sender, EventArgs e)
        {

        }

        private void Delete_OA_Button_Clicked(object sender, EventArgs e)
        {

        }

        private void Update_PA_Button_Clicked(object sender, EventArgs e)
        {

        }
        private void Delete_PA_Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}