using Android.App;
using Android.Widget;
using Android.OS;
using Android.Util;
using Android.Content;
using TaskyApp.ViewModels;

namespace TaskyApp.Droid
{
    [Activity(Label = "TaskyApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        private const string TAG = "MainActivity";

        private Button addTaskButton;
        private ListView taskListView;
        private TodoItemListAdapter taskList;

        private TodoItemsViewModel tasksViewModel;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            tasksViewModel = new TodoItemsViewModel();

            addTaskButton = FindViewById<Button>(Resource.Id.btn_add);
            if(addTaskButton != null)
            {
                addTaskButton.Click += delegate {
                    Log.Debug(TAG, "addTaskButton pressed");
                    StartActivity(typeof(TodoItemActivity));
                };
            }

            taskListView = FindViewById<ListView>(Resource.Id.lv_task_list);
            if(taskListView != null)
            {
                taskListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => 
                {
                    Log.Debug(TAG, "click item {0}", e.Position);
                    var taskDetails = new Intent(this, typeof(TodoItemActivity));
                    //var  currentTask = tasksViewModel.GetTask((int) e.Id);
                    //int id = currentTask.ID;
                    taskDetails.PutExtra("TaskID", (int) e.Id);
                    StartActivity(taskDetails);
                };
            }
        }


        protected override void OnResume()
        {
            base.OnResume();

            // create our adapter
            taskList = new TodoItemListAdapter(this, tasksViewModel.GetTasks());

            // hook up our adapter to our ListView
            taskListView.Adapter = (IListAdapter) taskList;
        }

    }
}

