using System;
using System.Collections.Generic;
using System.Text;

namespace JustinTownleyMobile
{
    class Term
    {
        public int TermID { get; set; }
        public string TermName { get; set; }
        public DateTime TermStart { get; set; }
        public DateTime TermEnd { get; set; }

        //constructor for current term
        public Term(int ID, string name, DateTime start, DateTime end)
        {
            TermID = ID;
            TermName = name;
            TermStart = start;
            TermEnd = end;
        }
    }
}
