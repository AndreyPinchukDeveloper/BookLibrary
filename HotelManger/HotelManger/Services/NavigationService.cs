using HotelManger.Stores;
using HotelManger.ViewModels;
using System;

namespace HotelManger.Services
{
    /// <summary>
    /// This class incapsulate our logic
    /// </summary>
    public class MyNavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;//can take maximum 16 parameters Func return value(Action return void)

        public MyNavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }
        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
