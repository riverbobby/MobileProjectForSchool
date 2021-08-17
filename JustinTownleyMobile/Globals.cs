using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace JustinTownleyMobile
{
    static class Globals
    {
        public static BindingList<Term> Terms = new BindingList<Term>();
        public static BindingList<Course> Courses = new BindingList<Course>();

        public static Term CurrentTerm { get; set; }
        public static Course CurrentCourse { get; set; }
        public static int CurrentTermID { get; set; }
        public static int currentCourseID { get; set; }

        //method for inserting into sqlite
        //public static bool Insert(string table, string values)
        //{
        //    bool success = false;
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return success;
        //}

        //method for updating into sqlite
        //public static bool Update(string table, string values, string IDName, int ID)
        //{
        //    bool success = false;
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return success;
        //}

        //method for deleting from sqlite
        //public static bool Delete(string table, string IDName, int ID)
        //{
        //    bool success = false;
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return success;
        //}
    }
}
