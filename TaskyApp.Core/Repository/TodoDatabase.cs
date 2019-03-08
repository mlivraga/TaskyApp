using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using TaskyApp.Models;

namespace TaskyApp.Repository
{
    /*
     * Class that manage the interaction with Database
     */
    public class TodoDatabase
    {
        static object locker = new object();

        public SQLiteConnection database;

        public string path;

        /*
         * Initialize a new instance
         */
        public TodoDatabase(SQLiteConnection conn)
        {
            database = conn;

            database.CreateTable<TodoItem>();
        }

        /*
         * Returns a list of items
         */
        public IEnumerable<TodoItem> GetItems()
        {
            lock (locker)
            {
                return (from i in database.Table<TodoItem>() select i).ToList();
            }

        }

        /*
         * Return a single item with the specified identifier
         */
        public TodoItem GetItem(int id)
        {
            lock (locker)
            {
                return database.Table<TodoItem>().FirstOrDefault(x => x.ID == id);
            }
        }

        /*
         * Save the item on the DB
         */
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

        /*
         * Delete one item by id on the DB
         */
        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<TodoItem>(id);
            }
        }



    }
}
