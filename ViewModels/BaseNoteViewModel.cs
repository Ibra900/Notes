using Microsoft.Toolkit.Mvvm.ComponentModel;
using Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.ViewModels
{
    public partial class BaseNoteViewModel : BaseViewModel
    {
        [ObservableProperty]
        private NoteInfo _noteInfo;

        public INavigation Navigation { get; set; }
    }
}
