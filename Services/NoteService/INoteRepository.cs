using Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Services.NoteService
{
    public interface INoteRepository
    {
        Task<bool> AddUpdateNoteAsync(NoteInfo noteInfo);

        Task<bool> DeleteNoteAsync(int noteId);

        Task<NoteInfo> GetNoteAsync(int noteId);
         
        Task<IEnumerable<NoteInfo>> GetNoteAsync();
    }
}
