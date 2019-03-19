// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TaskyApp.iOS
{
    [Register ("TaskDetailsViewController")]
    partial class TaskDetailsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton DeleteButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch DoneSwitch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView NotesText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SaveButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView TitleText { get; set; }

        [Action ("DeleteButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DeleteButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("SaveButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SaveButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (DeleteButton != null) {
                DeleteButton.Dispose ();
                DeleteButton = null;
            }

            if (DoneSwitch != null) {
                DoneSwitch.Dispose ();
                DoneSwitch = null;
            }

            if (NotesText != null) {
                NotesText.Dispose ();
                NotesText = null;
            }

            if (SaveButton != null) {
                SaveButton.Dispose ();
                SaveButton = null;
            }

            if (TitleText != null) {
                TitleText.Dispose ();
                TitleText = null;
            }
        }
    }
}