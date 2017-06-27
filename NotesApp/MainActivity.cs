using Android.App;
using Android.Widget;
using Android.OS;

namespace NotesApp
{
    [Activity(Label = "NotesApp", MainLauncher = true, Icon = "@drawable/icon", WindowSoftInputMode = Android.Views.SoftInput.StateVisible)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            EditText topicText = FindViewById<EditText>(Resource.Id.topicText);
            topicText.SetHint(Resource.String.topicTextPlaceHolder);
            EditText noteText = FindViewById<EditText>(Resource.Id.noteText);
            noteText.SetHint(Resource.String.noteTextPlaceHolder);

            var saveButton = FindViewById<Button>(Resource.Id.buttonSave);
            saveButton.Click += (object sender, System.EventArgs e) =>
            {
                var msg = topicText.Text + "\n" + noteText.Text;
                Toast.MakeText(ApplicationContext, msg, ToastLength.Long).Show();
            };

            
        }
    }
}

