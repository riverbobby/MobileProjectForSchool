using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace JustinTownleyMobile.Services
{
    static class DatabaseService
    {
        public static int CurrentTermID { get; set; }
        public static int CurrentCourseID { get; set; }

        static SQLiteConnection db;
        public static void Init()
        {
            if (db != null)
                return;

            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");

            db = new SQLiteConnection(databasePath);

            db.CreateTable<Term>();
            // add default table data
            var term = new Term
            {
                TermStart = DateTime.Now,
                TermEnd = DateTime.Now.AddDays(180),

            };
            db.Insert(term);

            db.CreateTable<Course>();
            // add default table data
            var course = new Course
            {
                TermID = 1,
                CourseName = "Course 1",
                CourseStart = DateTime.Now,
                CourseEnd = DateTime.Now.AddDays(30),
                CourseStatus = 4,
                CIName = "Justin Townley",
                CIPhone = "509-496-3180",
                CIEmail = "jtownl5@wgu.edu",
                Notes = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec tincidunt, nibh et rhoncus hendrerit, ligula ex faucibus justo, non accumsan nisi lacus at lorem. Nulla vehicula fermentum felis, non facilisis libero sagittis vel. Curabitur tortor velit, molestie at malesuada in, egestas id arcu. Nam egestas mollis sagittis. Nullam interdum malesuada diam sit amet imperdiet. Maecenas hendrerit sed eros at auctor. Maecenas vel ante lobortis, ultrices turpis a, congue sapien.",
                OAName = "OA 1",
                OAStart = DateTime.Now.AddDays(10),
                OAEnd = DateTime.Now.AddDays(11),
                PAName = "PA 1",
                PAStart = DateTime.Now.AddDays(20),
                PAEnd = DateTime.Now.AddDays(21)
            };
            db.Insert(course);


        }
        public static void AddCourse(Course course)
        {
            Init();

            db.Insert(course);
        }
        public static void UpdateCourse(Course course)
        {
            db.Update(course);
        } 
        public static void RemoveCourse(int id)
        {
            Init();

            db.Delete<Course>(id);
        }
        public static Course GetCourse(int id)
        {
            Init();
            var course = db.Get<Course>(id);
            return course;
        }

        public static IEnumerable<Course> GetCourses(int id)
        {
            Init();

            var courses = db.Table<Course>().Where(c=> c.TermID.Equals(id)).ToList();
            return courses;
        }
        public static void AddTerm(Term term)
        {
            Init();

            db.Insert(term);
        }
        public static void UpdateTerm(Term term)
        {
            db.Update(term);
        }

        public static void RemoveTerm(int id)
        {
            Init();
       
            db.Delete<Term>(id);
            //performing cascade delete on foreign key
            var courses = db.Table<Course>().Where(c => c.TermID.Equals(id)).ToList();
            foreach (Course c in courses)
            {
                db.Delete<Course>(c.CourseID);
            }
        }
        public static Term GetTerm(int id)
        {
            Init();
            
            var term = db.Get<Term>(id);
            return term;
        }
        public static IEnumerable<Term> GetTerms()
        {
            Init();

            var terms = db.Table<Term>().ToList();
            return terms;
        }

    }
}
