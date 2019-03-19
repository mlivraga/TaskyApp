using Foundation;
using System;
using System.Collections.Generic;
using TaskyApp.Models;
using TaskyApp.ViewModels;
using UIKit;

namespace TaskyApp.iOS
{
    public partial class TasksViewController : UITableViewController
    {
        TodoItemsViewModel tasksViewModel;

        public TasksViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            tasksViewModel = new TodoItemsViewModel();
        }


        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            List<TodoItem> tasks = (List<TodoItem>) tasksViewModel.GetTasks();

            TableView.Source = new RootTableSource(tasks.ToArray());
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "TaskSegue")
            { // set in Storyboard
                var navctlr = segue.DestinationViewController as TaskDetailsViewController;
                if (navctlr != null)
                {
                    var source = TableView.Source as RootTableSource;
                    var rowPath = TableView.IndexPathForSelectedRow;
                    var item = source.GetItem(rowPath.Row);
                    navctlr.SetTask(this, item); // to be defined on the TaskDetailViewController
                }
            }
        }



    }
}