using System;
using System.Collections.Generic;
using TaskyApp.Models;
using TaskyApp.Repository;
using UIKit;

namespace TaskyApp.iOS
{
    public partial class ViewController : UIViewController
    {
        List<TodoItem> tasks;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

        }


    }
}
