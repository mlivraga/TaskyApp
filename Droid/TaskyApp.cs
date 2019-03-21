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
        public static string TAG;

        public TaskyApp(IntPtr handle, global::Android.Runtime.JniHandleOwnership transfer) : base(handle,transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            TAG = Resources.GetString(Resource.String.app_name);
        }

    }
}
