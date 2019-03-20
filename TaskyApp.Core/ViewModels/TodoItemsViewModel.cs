using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
using TaskyApp.Models;
using TaskyApp.Repository;

namespace TaskyApp.ViewModels
{
    /// <summary>
    /// Menage the CRUD operations on the task items
    /// </summary>
    public class TodoItemsViewModel
    {
        public TodoItemManager TodoManager { get; set; }
        SQLiteConnection conn;

        public TodoItemsViewModel() {
            Inizializations();
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
            return TodoManager.GetTasks();
        }

        public TodoItem GetTask(int id)
        {
            return TodoManager.GetTask(id);
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
