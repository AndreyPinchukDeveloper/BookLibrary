using HotelManagerClassLibrary.Models;
using HotelManger.Commands;
using HotelManger.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HotelManger.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ReservationViewModel> _reservations;
        private readonly Hotel _hotel;

        public IEnumerable<ReservationViewModel> Reservations => _reservations;
        public ICommand MakeReservationCommand { get; }

        public ReservationListingViewModel(Hotel hotel, MyNavigationService makeReservationNavigationService)
        {
            _hotel = hotel;
            _reservations = new ObservableCollection<ReservationViewModel>();

            MakeReservationCommand = new NavigateCommand(makeReservationNavigationService);

            //TODO - use data from database

            UpdateReservations();
        }

        private void UpdateReservations()
        {
            _reservations.Clear();

            foreach (var reservation in _hotel.GetAllReservations())
            {
                ReservationViewModel reservationViewModel = new ReservationViewModel(reservation);
                _reservations.Add(reservationViewModel);
            }

        }
    }
}
