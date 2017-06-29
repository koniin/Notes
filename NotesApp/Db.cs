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
using System.IO;
using System.Threading.Tasks;

namespace NotesApp
{
    public class Db
    {
        private SQLiteConnector _sqlLiteConnector;
        public Db()
        {
            _sqlLiteConnector = new SQLiteConnector();
        }

        public void Init()
        {
            var filename = "Notes.db";
            _sqlLiteConnector.CreateDatabase(filename);
        }

        public void Save(Note note)
        {
            _sqlLiteConnector.Save(note);
        }

        public async Task<IEnumerable<Note>> List()
        {
            return await _sqlLiteConnector.All();
        }

        public void Delete(Note note)
        {
            _sqlLiteConnector.Delete(note);
        }
    }
}