using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using TaskyApp.Models;

namespace TaskyApp.Droid
{
    /// <summary>
    /// Adapter that presents Tasks in a row-view
    /// </summary>
    public class TodoItemListAdapter : BaseAdapter<TodoItem>
    {

        Activity context = null;
        IList<TodoItem> tasks = new List<TodoItem>();

        public TodoItemListAdapter(Activity activity, IList<TodoItem> items) : base()
        {
            this.context = activity;
            this.tasks = items;
        }

        public override TodoItem this[int position]
        {
            get { return tasks[position]; }
        }

        // Return the item id on the DB
        public override long GetItemId(int position)
        {
            return tasks[position].ID;
        }

        public override int Count {
            get { return tasks.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = tasks[position];

            var view = (convertView ??
                            context.LayoutInflater.Inflate(
                                        Android.Resource.Layout.SimpleListItemChecked,
                                        parent,
                                        false)) as CheckedTextView;

            view.SetText(item.Name == "" ? "<new task>" : item.Name, TextView.BufferType.Normal);
            view.Checked = item.Done;

            // Finally return the view
            return view;
        }

    }
}
