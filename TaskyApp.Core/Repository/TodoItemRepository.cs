using System;
using SQLite;
using System.Collections.Generic;
using TaskyApp.Repository;
using TaskyApp.Models;

namespace TaskyApp.Repository
{
    /// <summary>
    /// Singleton to access on DB, it's a wrapper for the TodoDatabase class
    /// </summary>
    public class TodoItemRepository
    {
        TodoDatabase db = null;

        public TodoItemRepository (SQLiteConnection conn)
        {
            db = new TodoDatabase(conn);
        }

        public TodoItem GetTask(int id)
        {
            return db.GetItem(id);
        }

        public IEnumerable<TodoItem> GetTasks()
        {
            return db.GetItems();
        }

        // Save == Update if the ID is the same
        public int SaveTask(TodoItem item)
        {
            return db.SaveItem(item);
        }

        public int DeleteTask(int id)
        {
            return db.DeleteItem(id);
        }

    }
}
