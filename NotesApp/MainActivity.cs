using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Linq;
using Android.Content;

namespace NotesApp
{
    [Activity(Label = "NotesApp", MainLauncher = true, Icon = "@drawable/icon", WindowSoftInputMode = Android.Views.SoftInput.StateVisible)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            EditText topicText = FindViewById<EditText>(Resource.Id.topicText);
            topicText.SetHint(Resource.String.topicTextPlaceHolder);
            EditText noteText = FindViewById<EditText>(Resource.Id.noteText);
            noteText.SetHint(Resource.String.noteTextPlaceHolder);

            var db = new Db();
            db.Init();

            var listButton = FindViewById<Button>(Resource.Id.buttonList);
            listButton.Click += (object sender, System.EventArgs e) =>
            {
                var intent = new Intent(this, typeof(NoteList));
                //intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
                StartActivity(intent);
            };

            var saveButton = FindViewById<Button>(Resource.Id.buttonSave);
            saveButton.Click += (object sender, System.EventArgs e) =>
            {
                var msg = topicText.Text + "\n" + noteText.Text;
                Toast.MakeText(ApplicationContext, msg, ToastLength.Long).Show();
                db.Save(new Note()
                {
                    CreateDate = DateTime.Now,
                    Topic = topicText.Text,
                    Text = noteText.Text
                });
            };

            var tbtn = FindViewById<Button>(Resource.Id.button1);
            tbtn.Click += async (object sender, System.EventArgs e) =>
            {
                var notes = await db.List();
                var firstNote = notes.First();
                db.Delete(firstNote);
                notes = await db.List();
                var tmp = string.Empty;
                foreach (var note in notes)
                {
                    tmp += note.ID + ", ";
                }
                
                //Toast.MakeText(ApplicationContext, firstNote.Topic + "\n" + firstNote.Text, ToastLength.Long).Show();
                Toast.MakeText(ApplicationContext, tmp, ToastLength.Long).Show();
            };
        }
    }
}

