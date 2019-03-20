using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using TaskyApp.Models;

namespace TaskyApp.Repository
{
    /// <summary>
    /// Class that manage the operations with the Database
    /// </summary>
    public class TodoDatabase
    {
        static object locker = new object();

        public SQLiteConnection database;

        public string path;


        public TodoDatabase(SQLiteConnection conn)
        {
            database = conn;

            database.CreateTable<TodoItem>();
        }

        public IEnumerable<TodoItem> GetItems()
        {
            lock (locker)
            {
                return (from i in database.Table<TodoItem>() select i).ToList();
            }

        }

        public TodoItem GetItem(int id)
        {
            lock (locker)
            {
                return database.Table<TodoItem>().FirstOrDefault(x => x.ID == id);
            }
        }

        public int SaveItem(TodoItem item)
        {
            lock (locker)
            {
                if(item.ID != 0)
                {
                    database.Update(item);
                    return item.ID;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<TodoItem>(id);
            }
        }

    }
}
