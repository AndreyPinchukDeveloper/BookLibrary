using ApplicationClassLibrary.Models;
using BookLibrary.Services;
using BookLibrary.Stores;
using BookLibrary.ViewModels;
using System;
using System.Windows;

namespace BookLibrary
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
        private MakeResrvationViewModel CreateMakeReservationViewModel()
        {
            return new MakeResrvationViewModel(_hotel, new MyNavigationService(_navigationStore, CreateReservationViewModel));
        }

        private ReservationListingViewModel CreateReservationViewModel()
        {
            return new ReservationListingViewModel(_hotel, new MyNavigationService(_navigationStore, CreateMakeReservationViewModel));
        }
    }
}
