using HotelManger.Exceptions;
using HotelManger.Models;
using HotelManger.Services;
using HotelManger.Stores;
using HotelManger.ViewModels;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace HotelManger.Commands
{
    public class MakeReservationCommand : AsyncCommandBase
    {
        private readonly MakeReservationViewModel _makeResrvationViewModel;
        private readonly HotelStore _hotelStore;
        private readonly MyNavigationService<ReservationListingViewModel> _reservationViewNavigationService;

        public MakeReservationCommand(
            MakeReservationViewModel makeResrvationViewModel, 
            HotelStore hotelStore, 
            MyNavigationService<ReservationListingViewModel> reservationViewNavigationService)
        {
            _makeResrvationViewModel = makeResrvationViewModel;
            _hotelStore = hotelStore;
            _reservationViewNavigationService = reservationViewNavigationService;

            _makeResrvationViewModel.PropertyChanged += OnViewModelPropertyChanged;//subscribe to propertyChnaged on our ViewModel
        }

        /// <summary>
        /// We come here while enter our Username
        /// </summary>
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeReservationViewModel.Username) ||
                e.PropertyName == nameof(MakeReservationViewModel.FloorNumber))
            {
                OnCanExecuteChanged();
            }
        }

        /// <summary>
        /// If username null or empty Submit button isn't available
        /// </summary>
        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_makeResrvationViewModel.Username) &&
                _makeResrvationViewModel.FloorNumber > 0 &&
                base.CanExecute(parameter);
        }

        /// <summary>
        /// Create new reservation and show user information about it
        /// </summary>
        public override async Task ExecuteAsync(object parameter)
        {
            Reservation reservation = new Reservation(
                new RoomID(
                    _makeResrvationViewModel.FloorNumber,
                    _makeResrvationViewModel.RoomNumber),
                    _makeResrvationViewModel.Username,
                    _makeResrvationViewModel.StartDate,
                    _makeResrvationViewModel.EndDate
                );

            try
            {
                await _hotelStore.MakeReservation(reservation);
                MessageBox.Show("Successfully reserved room.", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                _reservationViewNavigationService.Navigate();
            }
            catch (ReservationConflictException)
            {
                MessageBox.Show("This room is already taken. Please, choice another one.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to make reservation.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
