using System;
using Android.App;
using Android.OS;
using Android.Util;
using Android.Widget;
using TaskyApp.Models;
using TaskyApp.ViewModels;

namespace TaskyApp.Droid
{
    /// <summary>
    /// View/edit a Task
    /// </summary>
    [Activity(Label = "Tasky Details")]
    public class TodoItemActivity : Activity
    {
        TodoItem task = new TodoItem();
        Button cancelDeleteButton;
        EditText notesTextEdit;
        EditText nameTextEdit;
        Button saveButton;
        CheckBox doneCheckbox;

        private TodoItemsViewModel tasksViewModel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            tasksViewModel = new TodoItemsViewModel();

            int taskID = Intent.GetIntExtra("TaskID", 0);
            if(taskID > 0)
            {
                task = tasksViewModel.GetTask(taskID);
                Log.Debug(TaskyApp.TAG, "selected task {0}", task.ToString());
            }

            SetContentView(Resource.Layout.TaskDetails);
            nameTextEdit = FindViewById<EditText>(Resource.Id.NameText);
            notesTextEdit = FindViewById<EditText>(Resource.Id.NotesText);
            saveButton = FindViewById<Button>(Resource.Id.SaveButton);

            doneCheckbox = FindViewById<CheckBox>(Resource.Id.chkDone);
            doneCheckbox.Checked = task.Done;

            cancelDeleteButton = FindViewById<Button>(Resource.Id.CancelDeleteButton);
            cancelDeleteButton.Text = (task.ID == 0 ? "Cancel" : "Delete");

            nameTextEdit.Text = task.Name;
            notesTextEdit.Text = task.Notes;

            // button clicks
            cancelDeleteButton.Click += (sender, e) => { cancelDelete(); };
            saveButton.Click += (sender, e) => { Save(); };

        }

        void Save()
        {
            task.Name = nameTextEdit.Text;
            task.Notes = notesTextEdit.Text;
            task.Done = doneCheckbox.Checked;

            int saved = tasksViewModel.SaveTask(task);
            Console.WriteLine("SaveTesk value {0}", saved);
            Finish();
        }

        void cancelDelete()
        {
            if(task.ID != 0)
            {
                tasksViewModel.DeleteTask(task.ID);
            }
            Finish();
        }

    }
}
