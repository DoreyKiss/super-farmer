using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SuperFarmer.WPF.ViewModels
{
    public abstract class AbstractBaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
