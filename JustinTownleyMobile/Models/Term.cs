using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace JustinTownleyMobile
{
    public class Term
    {
        [PrimaryKey, AutoIncrement]
        public int TermID { get; set; }
        public string TermName { get; set; }
        public DateTime TermStart { get; set; }
        public DateTime TermEnd { get; set; }

        //default constructor for new term to be edited
        public Term()
        {
            TermStart = DateTime.Now;
            TermEnd = DateTime.Now.AddDays(1);
        }
        //constructor for current term
        //public Term(int ID, string name, DateTime start, DateTime end)
        //{
        //    TermID = ID;
        //    TermName = name;
        //    TermStart = start;
        //    TermEnd = end;
        //}
    }
}
