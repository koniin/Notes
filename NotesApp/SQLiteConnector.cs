using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.Threading.Tasks;
using System.IO;

namespace NotesApp
{
    public class SQLiteConnector
    {
        private SQLiteAsyncConnection _connection;

        public string CreateDatabase(string file)
        {
            //try
            //{
            string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), file);
            _connection = new SQLiteAsyncConnection(path, true);
                _connection.CreateTableAsync<Note>();
                return "Database created";
            //}
            //catch (SQLiteException ex)
            //{
            //    return ex.Message;
            //}
        }

        public void Save(Note note)
        {
            _connection.InsertAsync(note);
        }

        internal async Task<IEnumerable<Note>> All()
        {
            return await _connection.Table<Note>().ToListAsync();
        }

        public void Delete(Note note)
        {
            _connection.DeleteAsync(note);
        }
    }
}