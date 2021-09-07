using System.Collections.Generic;
using System.Collections.ObjectModel;
using JustinTownleyMobile.Models;
using JustinTownleyMobile.Services;

namespace JustinTownleyMobile.ViewModels
{
    public class TermViewModel
    {
        public ObservableCollection<Course> Courses { get; set; }
        public string TermName { get; set; }

        public TermViewModel()
        {
            Courses = new ObservableCollection<Course>();
            Refresh();
        }
        public void Refresh()
        {
            Courses.Clear();
            Term term = DatabaseService.GetTerm(DatabaseService.CurrentTermID);
            TermName = term.TermName;
            IEnumerable<Course> courses = DatabaseService.GetCourses(DatabaseService.CurrentTermID);
            foreach (Course c in courses)
            {
                Courses.Add(c);
            }
        }

    }
}
