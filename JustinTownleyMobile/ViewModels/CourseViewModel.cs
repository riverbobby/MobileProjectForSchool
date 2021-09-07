using JustinTownleyMobile.Models;
using JustinTownleyMobile.Services;

namespace JustinTownleyMobile.ViewModels
{
    public class CourseViewModel
    {
        public Course CurrentCourse { get; set; }
        public string Status { get; set; }

        public CourseViewModel()
        {
            Refresh();
        }
        private void Refresh()
        {
            Course course = DatabaseService.GetCourse(DatabaseService.CurrentCourseID);
            Status = GetString(course.CourseStatus);
            CurrentCourse = course;
        }
        private string GetString(int statusInt)
        {
            if (statusInt == 0)
            {
                return "in progress";
            }
            else if (statusInt == 1)
            {
                return "completed";
            }
            else if (statusInt == 2)
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
