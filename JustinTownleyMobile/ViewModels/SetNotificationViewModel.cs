using System;
using JustinTownleyMobile.Models;
using JustinTownleyMobile.Services;
using Xamarin.Forms;
using Plugin.LocalNotification;

namespace JustinTownleyMobile.ViewModels
{
    public class SetNotificationViewModel
    {
        public DateTime NotificationDate { get; set; }
        public TimeSpan NotificationTime { get; set; }
        //for radio buttons
        public bool c { get; set; }
        public bool o { get; set; }
        public bool p { get; set; }
        public bool s { get; set; }
        public bool e { get; set; }
        string type, startOrEnd;//calculated in CalculatedDays method
        public Course CurrentCourse { get; set; }
        public Command CancelCommand { get; }
        public Command SaveCommand { get; }

        public SetNotificationViewModel()
        {
            //load data
            NotificationDate = DateTime.Now;
            NotificationTime = new TimeSpan(0, 0, 0);
            c = true;
            s = true;
            Random random = new Random();
            Course course = DatabaseService.GetCourse(DatabaseService.CurrentCourseID);
            CurrentCourse = course;


            //commands for button clicks
            CancelCommand = new Command(
                execute: async () =>
                {
                    await Application.Current.MainPage.Navigation.PopAsync();
                });
            SaveCommand = new Command(
                execute: async () =>
                {

                    DateTime dateTime = NotificationDate.Date + NotificationTime;
                    int num = CalculateDays(dateTime);
                    var notification = new NotificationRequest
                    {
                        NotificationId = random.Next(),
                        Title = "WGU Scheduling",
                        Description = $"{type} {startOrEnd} in {num} days!",
                        NotifyTime = dateTime
                    };
                    NotificationCenter.Current.Show(notification);

                    await Application.Current.MainPage.Navigation.PopAsync();
                });
        }
        private int CalculateDays(DateTime dateTime)
        {
            int result = 0;
            //determine what radiobuttons are selected
            if (c)
            {
                type = CurrentCourse.CourseName;
                if (s)
                {
                    startOrEnd = "starts";
                    result = (CurrentCourse.CourseStart - dateTime).Days;
                }
                if (e)
                {
                    startOrEnd = "ends";
                    result = (CurrentCourse.CourseEnd - dateTime).Days;
                }
            }
            if (o)
            {
                type = CurrentCourse.OAName;
                if (s)
                {
                    startOrEnd = "starts";
                    result = (CurrentCourse.OAStart - dateTime).Days;
                }
                if (e)
                {
                    startOrEnd = "ends";
                    result = (CurrentCourse.OAEnd - dateTime).Days;
                }
            }
            if (p)
            {
                type = CurrentCourse.PAName;
                if (s)
                {
                    startOrEnd = "starts";
                    result = (CurrentCourse.PAStart - dateTime).Days;
                }
                if (e)
                {
                    startOrEnd = "ends";
                    result = (CurrentCourse.PAEnd - dateTime).Days;
                }
            }
            return result;
        }
    }
}
