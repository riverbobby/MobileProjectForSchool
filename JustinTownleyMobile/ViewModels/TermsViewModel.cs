using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JustinTownleyMobile.Services;
using JustinTownleyMobile.Views;
using System.Linq;
using Xamarin.Forms;

namespace JustinTownleyMobile.ViewModels
{
    public class TermsViewModel
    {
        public List<Term> Terms { get; set; }

        public TermsViewModel()
        {
            Terms = new List<Term>();
            Refresh();
        }
        async Task Refresh()
        {
            Terms.Clear();
            var terms = await DatabaseService.GetTerms();
            Terms.AddRange(terms);
        }
    }
}
