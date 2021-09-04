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
            Course localCourse = DatabaseService.GetCourse(DatabaseService.CurrentCourseID);

            await Share.RequestAsync(new ShareTextRequest
            {
                Text = localCourse.Notes,
                Title = $"{localCourse.CourseName} Notes"
            });
        }
        private async void Update_OA_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditOAView());
        }

        private async void Delete_OA_Button_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("This will delete assessment", "Cancel", "Delete");
            if (action == "Delete")
            {
                Course localCourse = DatabaseService.GetCourse(DatabaseService.CurrentCourseID);
                localCourse.OAName = "Please update assessment";
                localCourse.OAStart = localCourse.CourseStart.AddDays(20);
                localCourse.OAEnd = localCourse.CourseStart.AddDays(21);
                DatabaseService.UpdateCourse(localCourse);
                Navigation.InsertPageBefore(new CourseView(), this);
                await Navigation.PopAsync();
            }
        }

        private async void Update_PA_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditPAView());
        }
        private async void Delete_PA_Button_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("This will delete assessment", "Cancel", "Delete");
            if (action == "Delete")
            {
                Course localCourse = DatabaseService.GetCourse(DatabaseService.CurrentCourseID);
                localCourse.PAName = "Please update assessment";
                localCourse.PAStart = localCourse.CourseStart.AddDays(20);
                localCourse.PAEnd = localCourse.CourseStart.AddDays(21);
                DatabaseService.UpdateCourse(localCourse);
                Navigation.InsertPageBefore(new CourseView(), this);
                await Navigation.PopAsync();
            }

        }

        private async void Update_Class_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditCourseView());
        }

        private async void Delete_Class_Button_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Do you want to delete this class?", "Cancel", "Delete");
            if (action == "Delete")
            {
                DatabaseService.RemoveCourse(DatabaseService.CurrentCourseID);
                DatabaseService.CurrentCourseID = 0;
                await Navigation.PopAsync();
            }

        }
    }
}