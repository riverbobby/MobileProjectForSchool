using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JustinTownleyMobile.Models;
using JustinTownleyMobile.Services;
using JustinTownleyMobile.Views;
using System.Linq;
using Xamarin.Forms;

namespace JustinTownleyMobile.ViewModels
{
    public class EditOAViewModel
    {
        public Course Course { get; set; }

        public EditOAViewModel()
        {
            Refresh();
        }
        void Refresh()
        {
            Course course = DatabaseService.GetCourse(DatabaseService.CurrentCourseID);
            Course = course;
        }
        public void Save(Course course)
        {
            DatabaseService.UpdateCourse(course);
        }

    }
}
