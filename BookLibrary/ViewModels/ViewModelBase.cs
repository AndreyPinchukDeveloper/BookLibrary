using System.ComponentModel;

namespace BookLibrary.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This method is serving to tell UI what bindings is update
        /// </summary>
        protected void OnPropertyCHanged(string propertyName)//only for inheritors
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
