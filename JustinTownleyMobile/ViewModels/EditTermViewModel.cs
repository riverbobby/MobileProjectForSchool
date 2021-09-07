using System;
using System.ComponentModel;
using JustinTownleyMobile.Models;
using JustinTownleyMobile.Services;
using Xamarin.Forms;

namespace JustinTownleyMobile.ViewModels
{
    public class EditTermViewModel
    {
        //variables to allow for property changed event for validation
        public event PropertyChangedEventHandler PropertyChanged;
        private string _termName;
        private DateTime _termStart, _termEnd;
        public string termName { get => _termName; set { _termName = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(termName))); } }
        public DateTime termStart { get => _termStart; set { _termStart = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(termStart))); } }
        public DateTime termEnd { get => _termEnd; set { _termEnd = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(termEnd))); } }
        //variables for interacting with database and xaml
        public Term CurrentTerm { get; set; }
        public string Title { get; set; }
        public Command CancelCommand { get; }
        public Command SaveCommand { get; }

        public EditTermViewModel()
        {
            
            if (DatabaseService.CurrentTermID > 0)
            {
                Refresh();
            }
            else
            {
                Title = "New Term";
                CurrentTerm = new Term();
                termName = CurrentTerm.TermName;
                termStart = CurrentTerm.TermStart;
                termEnd = CurrentTerm.TermEnd;
            }
            CancelCommand = new Command(
                execute: async () =>
                {
                    await Application.Current.MainPage.Navigation.PopAsync();
                });
            SaveCommand = new Command(
                execute: async () =>
                {
                    CurrentTerm.TermName = termName;
                    CurrentTerm.TermStart = termStart;
                    CurrentTerm.TermEnd = termEnd;

                    if (DatabaseService.CurrentTermID > 0)
                    {
                        DatabaseService.UpdateTerm(CurrentTerm);
                    }
                    else
                    {
                        DatabaseService.AddTerm(CurrentTerm);
                    }
                    await Application.Current.MainPage.Navigation.PopAsync();
                },
                canExecute: () =>
                {
                    return !string.IsNullOrWhiteSpace(termName) &&
                           termStart <= termEnd;
                });
            this.PropertyChanged += EditTermViewModel_PropertyChanged;

        }

        private void EditTermViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            (SaveCommand as Command).ChangeCanExecute();
        }

        private void Refresh()
        {
            Term term = DatabaseService.GetTerm(DatabaseService.CurrentTermID);
            Title = "Update Term";
            CurrentTerm = term;
            termName = CurrentTerm.TermName;
            termStart = CurrentTerm.TermStart;
            termEnd = CurrentTerm.TermEnd;

        }
    }
}
