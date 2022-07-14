using HotelManagerClassLibrary.Models;
using HotelManger.Services;
using HotelManger.Stores;
using HotelManger.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HotelManger
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Hotel _hotel;
        private readonly NavigationStore _navigationStore;
        public App()
        {
            _hotel = new Hotel("Lovely Andre");
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateMakeReservationViewModel();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
        private MakeReservationViewModel CreateMakeReservationViewModel()
        {
            return new MakeReservationViewModel(_hotel, new MyNavigationService(_navigationStore, CreateReservationViewModel));
        }

        private ReservationListingViewModel CreateReservationViewModel()
        {
            return new ReservationListingViewModel(_hotel, new MyNavigationService(_navigationStore, CreateMakeReservationViewModel));
        }
    }
}
