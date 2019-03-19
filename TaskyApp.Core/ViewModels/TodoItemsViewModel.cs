using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
using TaskyApp.Models;
using TaskyApp.Repository;

namespace TaskyApp.ViewModels
{
    public class TodoItemsViewModel
    {
        private IList<TodoItem> tasks;

        public TodoItemManager TodoManager { get; set; }
        SQLiteConnection conn;

        public TodoItemsViewModel() {
            Inizializations();

            tasks = TodoManager.GetTasks();
        }

        private void Inizializations()
        {
            var sqliteFilename = "TodoItemDB.db3";
            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(libraryPath, sqliteFilename);
            conn = new SQLiteConnection(path);

            TodoManager = new TodoItemManager(conn);
        }

        public IList<TodoItem> GetTasks()
        {
            return tasks;
        }

        public TodoItem GetTask(int position)
        {
            return tasks[position];
        }

        public int SaveTask(TodoItem task)
        {
            return TodoManager.SaveTask(task);
        }

        public int DeleteTask(int id)
        {
            return TodoManager.DeleteTask(id);
        }

    }
}
