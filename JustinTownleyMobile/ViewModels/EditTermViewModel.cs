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
    public class EditTermViewModel
    {
        public Term Term { get; set; }

        public EditTermViewModel()
        {
            if (DatabaseService.CurrentTermID > 0)
            {
                Refresh();
            }
            else
            {
                Term = new Term();
            }
        }
        async Task Refresh()
        {
            var term = await DatabaseService.GetTerm(DatabaseService.CurrentTermID);
            Term = term;
        }

    }
}
