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
using System.Threading.Tasks;

namespace NotesApp
{
    [Activity(Label = "NoteList")]
    public class NoteList : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //var phoneNumbers = Intent.Extras.GetStringArrayList("phone_numbers") ?? new string[0];

            LoadList();
        }

        public void LoadList()
        {
            var db = new Db();
            db.Init();

            Task<IEnumerable<Note>> task = Task.Run(async () => await db.List());
            
            var notes = task.Result;
            List<string> items = new List<string>();
            foreach (Note n in notes)
            {
                items.Add(n.Topic);
            }
            
            ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);
        }
    }
}