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
using Plugin.LocalNotification;

namespace JustinTownleyMobile.ViewModels
{
    public class SetNotificationViewModel
    {
        public DateTime NotificationDate;
        public TimeSpan NotificationTime;
        public string Type, StartOrEnd;
        public Course CurrentCourse { get; set; }
        public Command CancelCommand { get; }
        public Command SaveCommand { get; }

        public SetNotificationViewModel()
        {
            //load data
            NotificationDate = DateTime.Now;
            NotificationTime = new TimeSpan(0, 0, 0);
            Type = "default type";
            StartOrEnd = "default startorend";
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
                    //fill in with local notification api calls
                    await Application.Current.MainPage.Navigation.PopAsync();
                });


        }
    }
}
