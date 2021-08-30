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
    public class TermViewModel
    {
        public List<Course> Courses { get; set; }

        public TermViewModel()
        {
            Courses = new List<Course>();
            Refresh();
        }
        async Task Refresh()
        {
            Courses.Clear();
            var courses = await DatabaseService.GetCourses(DatabaseService.CurrentTermID);
            Courses.AddRange(courses);
        }

    }
}
