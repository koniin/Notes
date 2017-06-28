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

namespace NotesApp
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Topic { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }

        public override string ToString()
        {
            return string.Format("[Person: ID={0}, Topic={1}, Text={2}]", ID, Topic, Text);
        }
    }
}