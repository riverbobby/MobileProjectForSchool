using System;
using System.Collections.Generic;
using System.Text;

namespace JustinTownleyMobile
{
    class Course
    {
        public int CourseID { get; set; }
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

        //constructor for current course
        public Course(int ID, string courseName, DateTime courseStart, DateTime courseEnd, int status, 
            string ciName, string ciPhone, string ciEmail, string notes, string oaName, DateTime oaStart, 
            DateTime oaEnd, string paName, DateTime paStart, DateTime paEnd)
        {
            CourseID = ID;
            CourseName = courseName;
            CourseStart = courseStart;
            CourseEnd = courseEnd;
            CourseStatus = status;
            CIName = ciName;
            CIPhone = ciPhone;
            CIEmail = ciEmail;
            Notes = notes;
            OAName = oaName;
            OAStart = oaStart;
            OAEnd = oaEnd;
            PAName = paName;
            PAStart = paStart;
            PAEnd = paEnd;

        }
    }
}
