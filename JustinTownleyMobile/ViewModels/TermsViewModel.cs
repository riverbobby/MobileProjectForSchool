using System.Collections.Generic;
using System.Collections.ObjectModel;
using JustinTownleyMobile.Models;
using JustinTownleyMobile.Services;

namespace JustinTownleyMobile.ViewModels
{
    public class TermsViewModel
    {
        public ObservableCollection<Term> Terms { get; set; }
        public TermsViewModel()
        {
            Terms = new ObservableCollection<Term>();
            Refresh();
        }
        private void Refresh()
        {
            Terms.Clear();
            IEnumerable<Term> terms = DatabaseService.GetTerms();
            foreach (Term t in terms)
            {
                Terms.Add(t);
            }
        }
    }
}
