using HotelManger.DbContexts;
using HotelManger.Models;
using HotelManger.Services;
using HotelManger.Services.ReservationConflictValidators;
using HotelManger.Services.ReservationCreators;
using HotelManger.Services.ReservationProviders;
using HotelManger.Stores;
using HotelManger.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace HotelManger
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Data Source = reservoom.db";
        private readonly Hotel _hotel;
        private readonly HotelStore _hotelStore;
        private readonly NavigationStore _navigationStore;
        private readonly ReservoomDbContextFactory _reservoomDbContextFactory;

        public App()
        {
            _reservoomDbContextFactory = new ReservoomDbContextFactory(CONNECTION_STRING);
            IReservationProvider reservationProvider = new DatabaseReservationProvider(_reservoomDbContextFactory);
            IReservationCreator reservationCreator = new DatabaseReservationCreator(_reservoomDbContextFactory);
            IReservationConflictValidator reservationConflictValidator = new DatabaseReservationConflictValidator(_reservoomDbContextFactory);

            ReservationBook reservationBook = new ReservationBook(reservationProvider, reservationCreator, reservationConflictValidator);

            _hotel = new Hotel("Lovely Andre", reservationBook);
            _hotelStore = new HotelStore(_hotel);
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using (ReservoomDbContext dbContext = _reservoomDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

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
            return new MakeReservationViewModel(
                _hotelStore, 
                new MyNavigationService(_navigationStore, CreateReservationViewModel));
        }

        private ReservationListingViewModel CreateReservationViewModel()
        {
            return ReservationListingViewModel.LoadViewModel(
                _hotelStore,
                new MyNavigationService(_navigationStore, CreateMakeReservationViewModel));
        }
    }
}
