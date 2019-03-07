using System;
using SQLite;

namespace TaskyApp.Models
{
    public class TodoItem
    {
        public TodoItem() { }

        // SQLite attributes
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }

    }
}
