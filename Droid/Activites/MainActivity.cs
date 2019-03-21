using Android.App;
using Android.Widget;
using Android.OS;
using Android.Util;
using Android.Content;
using TaskyApp.ViewModels;

namespace TaskyApp.Droid
{
    [Activity(Label = "Tasky", MainLauncher = true, Icon = "@mipmap/ic_launcher")]
    public class MainActivity : Activity
    {
        private Button addTaskButton;
        private ListView taskListView;

        // Mantain logic on shared code
        private TodoItemsViewModel tasksViewModel;
        TodoItemListAdapter listAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            tasksViewModel = new TodoItemsViewModel();

            addTaskButton = FindViewById<Button>(Resource.Id.btn_add);
            if(addTaskButton != null)
            {
                addTaskButton.Click += delegate {
                    Log.Debug(TaskyApp.TAG, "addTaskButton pressed");
                    StartActivity(typeof(TodoItemActivity));
                };
            }

            taskListView = FindViewById<ListView>(Resource.Id.lv_task_list);
            if(taskListView != null)
            {
                taskListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => 
                {
                    Log.Debug(TaskyApp.TAG, "click item {0} and ID {1}", e.Position, e.Id);
                    var taskDetails = new Intent(this, typeof(TodoItemActivity));
                    taskDetails.PutExtra("TaskID", (int) e.Id);
                    StartActivity(taskDetails);
                };
            }

            listAdapter = new TodoItemListAdapter(this, tasksViewModel.GetTasks());
        }


        protected override void OnResume()
        {
            base.OnResume();

            taskListView.Adapter = new TodoItemListAdapter(this, tasksViewModel.GetTasks());
        }

    }
}

