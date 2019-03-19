using System;
using System.IO;
using Android.App;
using SQLite;
using TaskyApp.Repository;

namespace TaskyApp.Droid
{
    [Application]
    public class TaskyApp : Application
    {
        public static TaskyApp Current { get; private set; }

        public static string TAG;

        public TaskyApp(IntPtr handle, global::Android.Runtime.JniHandleOwnership transfer) : base(handle,transfer)
        {
            Current = this;
        }

        public override void OnCreate()
        {
            base.OnCreate();

            TAG = Resources.GetString(Resource.String.app_name);
        }

    }
}
