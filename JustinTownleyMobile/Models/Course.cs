using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace JustinTownleyMobile.Models
{
    public class Course
    {
        [PrimaryKey, AutoIncrement]
        public int CourseID { get; set; }
        [Indexed]
        public int TermID { get; set; }
        public string CourseName { get; set; }
        public DateTime CourseStart { get; set; }
        public DateTime CourseEnd { get; set; }
        public int CourseStatus { get; set; }
        public string CIName { get; set; }
        public string CIPhone { get; set; }
        public string CIEmail { get; set; }
        public string Notes { get; set; }
        public string OAName { get; set; }
        public DateTime OAStart { get; set; }
        public DateTime OAEnd { get; set; }
        public string PAName { get; set; }
        public DateTime PAStart { get; set; }
        public DateTime PAEnd { get; set; }

        //default constructor for adding new Course
        public Course()
        {
            TermID = Services.DatabaseService.CurrentTermID;
            CourseName = "";
            CourseStart = DateTime.Now;
            CourseEnd = DateTime.Now.AddDays(1);
            CourseStatus = 3; // 3 = plan to take
            CIName = "";
            CIEmail = "";
            CIPhone = "";
            Notes = "";
            OAStart = DateTime.Now;
            OAEnd = DateTime.Now.AddDays(1);
            PAStart = DateTime.Now;
            PAEnd = DateTime.Now.AddDays(1);
        }
    }
}
