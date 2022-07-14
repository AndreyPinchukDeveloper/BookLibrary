using HotelManger.Stores;
using HotelManger.ViewModels;
using System;

namespace HotelManger.Services
{
    /// <summary>
    /// This class incapsulate our logic
    /// </summary>
    public class MyNavigationService
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<ViewModelBase> _createViewModel;//can take maximum 16 parameters Func return value(Action return void)

        public MyNavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
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
