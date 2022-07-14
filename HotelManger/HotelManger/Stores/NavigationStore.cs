using HotelManger.ViewModels;
using System;

namespace HotelManger.Stores
{
    /// <summary>
    /// Store ViewModel for our application
    /// </summary>
    public class NavigationStore
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set//good place to dispose view models
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public event Action CurrentViewModelChanged;
    }
}
