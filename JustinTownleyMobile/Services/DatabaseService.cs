﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace JustinTownleyMobile.Services
{
    static class DatabaseService
    {
        public static int CurrentTermID { get; set; }
        public static int CurrentCourseID { get; set; }

        static SQLiteAsyncConnection db;
        public static async Task Init()
        {
            if (db != null)
                return;

            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Term>();
            // add default table data
            var term = new Term
            {
                TermStart = DateTime.Now,
                TermEnd = DateTime.Now.AddDays(180),

            };
            await db.InsertAsync(term);

            await db.CreateTableAsync<Course>();
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
            await db.InsertAsync(course);


        }
        public static async Task AddCourse(int termID, string courseName, DateTime courseStart, DateTime courseEnd, int status,
            string ciName, string ciPhone, string ciEmail, string notes, string oaName, DateTime oaStart,
            DateTime oaEnd, string paName, DateTime paStart, DateTime paEnd)
        {
            await Init();
            var course = new Course
            {
                TermID = termID,
                CourseName = courseName,
                CourseStart = courseStart,
                CourseEnd = courseEnd,
                CourseStatus = status,
                CIName = ciName,
                CIPhone = ciPhone,
                CIEmail = ciEmail,
                Notes = notes,
                OAName = oaName,
                OAStart = oaStart,
                OAEnd = oaEnd,
                PAName = paName,
                PAStart = paStart,
                PAEnd = paEnd
        };

            await db.InsertAsync(course);
        }
        public static async Task RemoveCourse(int id)
        {
            await Init();

            await db.DeleteAsync<Course>(id);
        }
        public static async Task<Course> GetCourse(int id)
        {
            await Init();
            var course = await db.GetAsync<Course>(id);
            return course;
        }

        public static async Task<List<Course>> GetCourses(int id)
        {
            await Init();
            //add <where> linq (I don't like it yet)...
            var courses = await db.Table<Course>().Where(a=> a.TermID.Equals(id)).ToListAsync();
            return courses;
        }
        public static async Task AddTerm(DateTime termStart, DateTime termEnd)
        {
            await Init();
            var term = new Term
            {
                TermStart = termStart,
                TermEnd = termEnd
            };

            var id = await db.InsertAsync(term);
        }
        public static async Task RemoveTerm(int id)
        {
            await Init();
            // need code to create cascading delete for foreign key
            await db.DeleteAsync<Term>(id);
        }
        public static async Task<Term> GetTerm(int id)
        {
            await Init();
            var term = await db.GetAsync<Term>(id);
            return term;
        }
        public static async Task<List<Term>> GetTerms()
        {
            await Init();

            var terms = await db.Table<Term>().ToListAsync();
            return terms;
        }

    }
}