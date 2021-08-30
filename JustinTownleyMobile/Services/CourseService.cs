using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;
using System.Threading.Tasks;

namespace JustinTownleyMobile.Services
{
    public static class CourseService
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null)
                return;

            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Course>();
            // add default table data
            await db.CreateTableAsync<Term>();
            // add default table data
        }
        public static async Task AddCourse()
        {
            await Init();
            var course = new Course
            {
                //fill in class defiinitions
            };

            var id = await db.InsertAsync(course);
        }
        public static async Task RemoveCourse(int id)
        {
            await Init();

            await db.DeleteAsync<Course>(id);
        }
        public static async Task<IEnumerable<Course>> GetCourse()
        {
            await Init();

            var course = await db.Table<Course>().ToListAsync();
            return course;
        }
    }
}
