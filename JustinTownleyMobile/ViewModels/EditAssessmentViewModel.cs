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
    public class EditAssessmentViewModel
    {
        public Course Course { get; set; }

        public EditAssessmentViewModel()
        {
            Refresh();
        }
        async Task Refresh()
        {
            var course = await DatabaseService.GetCourse(DatabaseService.CurrentCourseID);
            Course = course;
        }
        async Task Save()
        {
            await DatabaseService.UpdateCourse(Course);
        }

    }
}
