﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JustinTownleyMobile.Services;
using JustinTownleyMobile.Models;
using JustinTownleyMobile.Views;
using System.Linq;
using Xamarin.Forms;

namespace JustinTownleyMobile.ViewModels
{
    public class CourseViewModel
    {
        public Course Course { get; set; }

        public CourseViewModel()
        {
            Refresh();
        }
        private void Refresh()
        {
            Course course = DatabaseService.GetCourse(DatabaseService.CurrentCourseID);
            Course = course;
        }
        public void SaveNotes()
        {
            DatabaseService.UpdateCourse(Course);
            Refresh();
        }

    }
}
