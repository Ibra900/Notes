using Notes.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Services.NoteService
{
    public class NoteService : INoteRepository
    {
        public SQLiteAsyncConnection _database;
        public NoteService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<NoteInfo>().Wait();
        }
        public async Task<bool> AddUpdateNoteAsync(NoteInfo noteInfo)
        {
            if (noteInfo.NoteId > 0)
            {
                await _database.UpdateAsync(noteInfo);
            }
            else
            {
                await _database.InsertAsync(noteInfo);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteNoteAsync(int noteId)
        {
            await _database.DeleteAsync<NoteInfo>(noteId);
            return await Task.FromResult(true);
        }

        public async Task<NoteInfo> GetNoteAsync(int noteId)
        {
            return await _database.Table<NoteInfo>().Where(n => n.NoteId == noteId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<NoteInfo>> GetNoteAsync()
        {
            return await Task.FromResult(await _database.Table<NoteInfo>().ToListAsync());
        }
    }
}