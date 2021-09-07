using System;
using System.ComponentModel;
using JustinTownleyMobile.Models;
using JustinTownleyMobile.Services;
using Xamarin.Forms;

namespace JustinTownleyMobile.ViewModels
{
    public class EditPAViewModel
    {
        //variables to allow for property changed event for validation
        public event PropertyChangedEventHandler PropertyChanged;
        private string _pAName;
        private DateTime _pAStart, _pAEnd;
        public string pAName { get => _pAName; set { _pAName = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(pAName))); } }
        public DateTime pAStart { get => _pAStart; set { _pAStart = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(pAStart))); } }
        public DateTime pAEnd { get => _pAEnd; set { _pAEnd = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(pAEnd))); } }
        //variables for interacting with database and xaml
        public Course CurrentCourse { get; set; }
        public Command CancelCommand { get; }
        public Command SaveCommand { get; }

        public EditPAViewModel()
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
                    CurrentCourse.PAName = pAName;
                    CurrentCourse.PAStart = pAStart;
                    CurrentCourse.PAEnd = pAEnd;
                    DatabaseService.UpdateCourse(CurrentCourse);
                    await Application.Current.MainPage.Navigation.PopAsync();
                },
                canExecute: () =>
                {
                    return !string.IsNullOrWhiteSpace(pAName) &&
                           pAStart <= pAEnd &&
                           pAStart >= CurrentCourse.CourseStart &&
                           pAEnd <= CurrentCourse.CourseEnd;
                });
            this.PropertyChanged += EditPAViewModel_PropertyChanged;
        }
        private void EditPAViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            (SaveCommand as Command).ChangeCanExecute();
        }
        void Refresh()
        {
            Course course = DatabaseService.GetCourse(DatabaseService.CurrentCourseID);
            CurrentCourse = course;
            pAName = CurrentCourse.PAName;
            pAStart = CurrentCourse.PAStart;
            pAEnd = CurrentCourse.PAEnd;

        }
    }
}
