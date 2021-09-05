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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace JustinTownleyMobile.ViewModels
{
    public class EditCourseViewModel
    {
        //variables to allow for property changed event for validation
        public event PropertyChangedEventHandler PropertyChanged;
        private string _courseName, _cIName, _cIPhone, _cIEmail, _notes;
        private int _courseStatus;
        private DateTime _courseStart, _courseEnd;
        public string courseName { get => _courseName; set { _courseName = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(courseName))); } }
        public DateTime courseStart { get => _courseStart; set { _courseStart = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(courseStart))); } }
        public DateTime courseEnd { get => _courseEnd; set { _courseEnd = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(courseEnd))); } }
        public int courseStatus { get => _courseStatus; set { _courseStatus = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(courseStatus))); } }
        public string cIName { get => _cIName; set { _courseName = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(cIName))); } }
        public string cIPhone { get => _cIPhone; set { _cIPhone = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(cIPhone))); } }
        public string cIEmail { get => _cIEmail; set { _cIEmail = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(cIEmail))); } }
        public string notes { get => _notes; set { _notes = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(notes))); } }
        //variables for interacting with database and xaml
        public Course CurrentCourse { get; set; }
        public DateTime TermStart { get; set; }
        public DateTime TermEnd { get; set; }
        public string Title { get; set; }
        public ObservableCollection<string> PickerDisplay { get; set; }
        public Command CancelCommand { get; }
        public Command SaveCommand { get; }
        //regex for phoneNumber (obtained from https://www.csharp-console-examples.com/csharp-console/simple-regular-expression-phone-number-validation-in-c/ on 09/05/2021)
        public const string PhoneRegex = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
        //regex for email (obtained from https://code.4noobz.net/c-email-validation/ on 09/05/2021)
        public const string EmailRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";


        public EditCourseViewModel()
        {
            Term term = DatabaseService.GetTerm(DatabaseService.CurrentTermID);
            TermStart = term.TermStart;
            TermEnd = term.TermEnd;
            PickerDisplay = new ObservableCollection<string>();
            PopulatePickerDisplay();
            //determine if add or update course
            if (DatabaseService.CurrentCourseID > 0)
            {
                Refresh();
            }
            else
            {
                Title = "New Course";
                Course course = new Course();
                courseName = course.CourseName;
                courseStart = course.CourseStart;
                courseEnd = course.CourseStart;
                courseStatus = course.CourseStatus;
                cIName = course.CIName;
                cIPhone = course.CIPhone;
                cIEmail = course.CIEmail;
                notes = course.Notes;
                CurrentCourse = course;
            }
            CancelCommand = new Command(
                execute: async () =>
                {
                    await Application.Current.MainPage.Navigation.PopAsync();
                });
                        SaveCommand = new Command(
                            execute: async () =>
                            {
                                CurrentCourse.CourseName = courseName;
                                CurrentCourse.CourseStart = courseStart;
                                CurrentCourse.CourseEnd = courseEnd;
                                CurrentCourse.CourseStatus = courseStatus;
                                CurrentCourse.CIName = cIName;
                                CurrentCourse.CIPhone = cIPhone;
                                CurrentCourse.CIEmail = cIEmail;
                                CurrentCourse.Notes = notes;
                                if (DatabaseService.CurrentCourseID > 0)
                                {
                                    DatabaseService.UpdateCourse(CurrentCourse);
                                }
                                else
                                {
                                    DatabaseService.AddCourse(CurrentCourse);
                                }
                                await Application.Current.MainPage.Navigation.PopAsync();
                            },
                            canExecute: () =>
                            {
                                return !(string.IsNullOrWhiteSpace(courseName) ||
                                       string.IsNullOrWhiteSpace(cIName) ||
                                       string.IsNullOrWhiteSpace(cIPhone) || 
                                       string.IsNullOrWhiteSpace(cIEmail)) &&
                                       courseStart <= courseEnd &&
                                       courseStart >= TermStart &&
                                       courseEnd <= TermEnd &&
                                       Regex.IsMatch(cIPhone, PhoneRegex) &&
                                       Regex.IsMatch(cIEmail, EmailRegex, RegexOptions.IgnoreCase);
                            });
            this.PropertyChanged += EditCourseViewModel_PropertyChanged;

        }
        private void EditCourseViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            (SaveCommand as Command).ChangeCanExecute();
        }
        private void Refresh()
        {
            Title = "Edit Course";
            Course course = DatabaseService.GetCourse(DatabaseService.CurrentCourseID);
            CurrentCourse = course;
            courseName = course.CourseName;
            courseStart = course.CourseStart;
            courseEnd = course.CourseStart;
            courseStatus = course.CourseStatus;
            cIName = course.CIName;
            cIPhone = course.CIPhone;
            cIEmail = course.CIEmail;
            notes = course.Notes;
        }
        private void PopulatePickerDisplay()
        {
            PickerDisplay.Clear();
            PickerDisplay.Add("in progress");
            PickerDisplay.Add("completed");
            PickerDisplay.Add("dropped");
            PickerDisplay.Add("plan to take");
        }
    }
}
