using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using JustinTownleyMobile.Models;
using JustinTownleyMobile.Services;
using JustinTownleyMobile.Views;
using System.Linq;
using Xamarin.Forms;

namespace JustinTownleyMobile.ViewModels
{
    public class CourseViewModel
    {
        public Course Course { get; set; }
        public string Status { get; set; }

        public CourseViewModel()
        {
            Refresh();
        }
        private void Refresh()
        {
            Course course = DatabaseService.GetCourse(DatabaseService.CurrentCourseID);
            Status = GetStatus(course.CourseStatus);
            Course = course;
        }
        private string GetStatus(int statusInt)
        {
            if (statusInt == 1)
            {
                return "in progress";
            }
            else if (statusInt == 2)
            {
                return "completed";
            }
            else if (statusInt == 3)
            {
                return "dropped";
            }
            else
            {
                return "plan to take";
            }

        }
    }
}
