using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HelloMvvm.ViewModels
{
    public abstract class ViewModel: INotifyPropertyChanged, INotifyPropertyChanging
    {
        #region INotifyPropertyChanged implementation
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            if (!string.IsNullOrWhiteSpace(propertyName) && PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        } 
        
        #endregion

        #region INotifyPropertyChanging implementation
        
        public event PropertyChangingEventHandler PropertyChanging;

        protected void RaisePropertyChanging(string propertyName)
        {
            if (!string.IsNullOrWhiteSpace(propertyName) && PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion
    }
}
