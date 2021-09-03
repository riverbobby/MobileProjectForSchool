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
    public class TermViewModel
    {
        public ObservableCollection<Course> Courses { get; set; }
        public string TermName { get; set; }

        public TermViewModel()
        {
            Courses = new ObservableCollection<Course>();
            Refresh();
        }
        private void Refresh()
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
