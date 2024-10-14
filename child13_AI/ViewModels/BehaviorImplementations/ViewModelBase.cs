using System;
using System.ComponentModel;

namespace child13_AI.ViewModels
{
    internal abstract partial class ViewModelBase : INotifyPropertyChanged
    {
        public ViewModelBase()
        {
            PropertyChanged += ViewModelReactionToPropertyChanged;
        }

        protected void OnPropertyChanged(in PropertyChangedEventArgs inPropertyChangedEventArgs) =>
            PropertyChanged?.Invoke(this, inPropertyChangedEventArgs);

        protected virtual void ViewModelReactionToPropertyChanged(object inSender, PropertyChangedEventArgs inPropertyChangedEventArgs)
        { }
    }
}
