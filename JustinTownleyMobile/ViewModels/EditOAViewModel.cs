using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using JustinTownleyMobile.Models;
using JustinTownleyMobile.ViewModels;
using JustinTownleyMobile.Views;
using JustinTownleyMobile.Services;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace JustinTownleyMobile.ViewModels
{
    public class EditOAViewModel
    {
        //variables to allow for property changed event for validation
        public event PropertyChangedEventHandler PropertyChanged;
        private string _oAName;
        private DateTime _oAStart, _oAEnd;
        public string oAName { get => _oAName; set { _oAName = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(oAName))); } }
        public DateTime oAStart { get => _oAStart; set { _oAStart = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(oAStart))); } }
        public DateTime oAEnd { get => _oAEnd; set { _oAEnd = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(oAEnd))); } }
        //variables for interacting with database and xaml
        public Course CurrentCourse { get; set; }
        public Command CancelCommand { get; }
        public Command SaveCommand { get; }

        public EditOAViewModel()
        {
            Refresh();
            CancelCommand = new Command(
                execute: async () =>
                {
                    await Application.Current.MainPage.Navigation.PopAsync();
                });
            SaveCommand = new Command(
                execute: async () =>
                {
                    CurrentCourse.OAName = oAName;
                    CurrentCourse.OAStart = oAStart;
                    CurrentCourse.OAEnd = oAEnd;
                    DatabaseService.UpdateCourse(CurrentCourse);
                    await Application.Current.MainPage.Navigation.PopAsync();
                },
                canExecute: () =>
                {
                    return !string.IsNullOrWhiteSpace(oAName) &&
                           oAStart <= oAEnd &&
                           oAStart >= CurrentCourse.CourseStart &&
                           oAEnd <= CurrentCourse.CourseEnd;
                });
            this.PropertyChanged += EditOAViewModel_PropertyChanged;
        }
        private void EditOAViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            (SaveCommand as Command).ChangeCanExecute();
        }
        void Refresh()
        {
            Course course = DatabaseService.GetCourse(DatabaseService.CurrentCourseID);
            oAName = course.OAName;
            oAStart = course.OAStart;
            oAEnd = course.OAEnd;
            CurrentCourse = course;
        }
    }
}
