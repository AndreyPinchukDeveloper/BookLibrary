using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManger.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This method is serving to tell UI what bindings is update
        /// </summary>
        protected void OnPropertyChanged(string propertyName)//only for inheritors
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
