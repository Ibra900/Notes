using Microsoft.Toolkit.Mvvm.Input;
using Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.ViewModels 
{
    public partial class AddNotePageViewModel : BaseNoteViewModel
    {
        public AddNotePageViewModel()
        {
            NoteInfo = new NoteInfo();
        }

        [ICommand]
        public async void SaveNote()
        {
            var note = NoteInfo;
            await App.NoteService.AddUpdateNoteAsync(note);

            await Shell.Current.GoToAsync("..");
        }

        [ICommand]
        public async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
