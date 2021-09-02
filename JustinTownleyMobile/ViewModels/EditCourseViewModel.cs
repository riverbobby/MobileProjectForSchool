using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JustinTownleyMobile.Services;
using JustinTownleyMobile.Views;
using System.Linq;
using Xamarin.Forms;

namespace JustinTownleyMobile.ViewModels
{
    public class EditCourseViewModel
    {
        public Course Course { get; set; }

        public EditCourseViewModel()
        {
            if (DatabaseService.CurrentCourseID > 0)
            {
                Refresh();
            }
            else
            {
                Course = new Course();
            }
        }
        private void Refresh()
        {
            Course course = DatabaseService.GetCourse(DatabaseService.CurrentCourseID);
            Course = course;
        }
        public void Save()
        {
            if (DatabaseService.CurrentCourseID > 0)
            {
                DatabaseService.UpdateCourse(Course);
            }
            else
            {
                DatabaseService.AddCourse(Course);
            }
        }
    }
}
