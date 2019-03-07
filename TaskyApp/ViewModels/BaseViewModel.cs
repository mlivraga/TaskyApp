using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaskyApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
