using System;
using SQLite;

namespace JustinTownleyMobile.Models
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
    }
}
