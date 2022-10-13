using Microsoft.Toolkit.Mvvm.Input;
using Notes.Models;
using Notes.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.ViewModels
{
    public partial class NotePageViewModel:BaseNoteViewModel
    {
        public ObservableCollection<NoteInfo> noteList { get; }
        public NotePageViewModel(INavigation navigation)
        {
            noteList = new ObservableCollection<NoteInfo>();
            Navigation = navigation;
        }

        [ICommand]
        private async void OnAddNote()
        {
            await Shell.Current.GoToAsync(nameof(AddNotePage));
        } 

        public void OnAppearing()
        {
            IsBusy = true;
        }

        [ICommand]
        private async Task LoadNotes()
        {
            IsBusy = true;

            try
            {
                noteList.Clear();
                var notList = await App.NoteService.GetNoteAsync();
                foreach(var item in notList)
                {
                    noteList.Add(item);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        [ICommand]
        private async void NoteTappedDelete(NoteInfo noteInfo)
        {
            if (noteInfo == null)
                return;
            await App.NoteService.DeleteNoteAsync(noteInfo.NoteId);
            await LoadNotes();
            OnAppearing();
        }

        [ICommand]
        private async void NoteTappedEdit(NoteInfo noteInfo)
        {
            if (noteInfo == null)
                return;
            await Navigation.PushAsync(new AddNotePage(noteInfo));
        }
    }
}
