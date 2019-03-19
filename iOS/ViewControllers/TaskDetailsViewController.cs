using Foundation;
using System;
using TaskyApp.Models;
using TaskyApp.ViewModels;
using UIKit;

namespace TaskyApp.iOS
{
    public partial class TaskDetailsViewController : UIViewController
    {

        TodoItem currentTask { get; set; }
        TodoItemsViewModel tasksViewModel;


        public TaskDetailsViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            tasksViewModel = new TodoItemsViewModel();
        }

        partial void SaveButton_TouchUpInside(UIButton sender)
        {
            if(currentTask != null)
            {
                tasksViewModel.SaveTask(currentTask);
            }
            else
            {
                TodoItem currentItem = new TodoItem();
                currentItem.Name = TitleText.Text;
                currentItem.Notes = NotesText.Text;

                if (DoneSwitch.On)
                    currentItem.Done = true;
                else
                    currentItem.Done = false;

                tasksViewModel.SaveTask(currentItem);
            }

        }

        partial void DeleteButton_TouchUpInside(UIButton sender)
        {
            tasksViewModel.DeleteTask(currentTask.ID);
        }

        public TasksViewController Delegate { get; set; } // will be used to Save, Delete later


        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if(currentTask != null)
            {
                TitleText.Text = currentTask.Name;
                NotesText.Text = currentTask.Notes;
                DoneSwitch.On = currentTask.Done;
            }

        }

        // this will be called before the view is displayed
        public void SetTask(TasksViewController d, TodoItem task)
        {
            Delegate = d;
            currentTask = task;
        }

        public void SaveTask(TodoItem saveItem)
        {
            tasksViewModel.SaveTask(saveItem);
            NavigationController.PopViewController(true);
        }


        public void DeleteTask(int id)
        {
            tasksViewModel.DeleteTask(id);
            NavigationController.PopViewController(true);
        }


    }
}