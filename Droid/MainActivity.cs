using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections;
using System.Collections.Generic;
using TaskyApp.Models;
using Android.Util;
using System;
using Android.Content;
using TaskyApp.Repository;

namespace TaskyApp.Droid
{
    [Activity(Label = "TaskyApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

        private const string TAG = "MainActivity";
        private TodoItemListAdapter taskList;
        private IList<TodoItem> tasks;
        private Button addTaskButton;
        private ListView taskListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            addTaskButton = FindViewById<Button>(Resource.Id.btn_add);
            if(addTaskButton != null)
            {
                addTaskButton.Click += delegate {
                    Log.Debug(TAG, "Button pressed");
                    StartActivity(typeof(TodoItemScreen));
                };
            }

            taskListView = FindViewById<ListView>(Resource.Id.lv_task_list);
            if(taskListView != null)
            {
                taskListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => 
                {
                    var taskDetails = new Intent(this, typeof(TodoItemScreen));
                    taskDetails.PutExtra("TaskID", tasks[e.Position].ID);
                    StartActivity(taskDetails);
                };
            }
        }


        protected override void OnResume()
        {
            base.OnResume();

            // access to TaskyApp class
            tasks = TaskyApp.Current.TodoManager.GetTasks();

            // create our adapter
            taskList = new TodoItemListAdapter(this, tasks);

            // hook up our adapter to our ListView
            taskListView.Adapter = (IListAdapter) taskList;
        }

    }
}

