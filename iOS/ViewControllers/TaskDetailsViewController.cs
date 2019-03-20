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
            TodoItem newItem = new TodoItem();

            if (currentTask != null)
                newItem.ID = currentTask.ID;

            newItem.Name = TitleText.Text.Equals("") ? "np" : TitleText.Text;
            newItem.Notes = NotesText.Text;

            if (DoneSwitch.On)
                newItem.Done = true;
            else
                newItem.Done = false;

            tasksViewModel.SaveTask(newItem);

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
            this.NavigationController.PopViewController(true);
        }


        public void DeleteTask(int id)
        {
            tasksViewModel.DeleteTask(id);
           
        }


    }
}