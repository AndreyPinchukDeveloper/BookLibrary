using ApplicationClassLibrary.Eceptions;
using ApplicationClassLibrary.Models;
using BookLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookLibrary.Commands
{
    public class MakeReservationCommand:CommandBase
    {
        private readonly MakeResrvationViewModel _makeResrvationViewModel;
        private readonly Hotel _hotel;

        public MakeReservationCommand(MakeResrvationViewModel makeResrvationViewModel, Hotel hotel)
        {
            _makeResrvationViewModel = makeResrvationViewModel;
            _hotel = hotel;

            _makeResrvationViewModel.PropertyChanged += OnViewModelPropertyChanged;//subscribe to propertyChnaged on our ViewModel
        }

        /// <summary>
        /// We come here while enter our Username
        /// </summary>
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeResrvationViewModel.Username)||
                e.PropertyName == nameof(MakeResrvationViewModel.FloorNumber))
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
                _makeResrvationViewModel.FloorNumber>0 &&
                base.CanExecute(parameter);
        }

        /// <summary>
        /// Create new reservation and show user information about it
        /// </summary>
        public override void Execute(object parameter)
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
                _hotel.MakeReservation(reservation);
                MessageBox.Show("Successfully reserved room.", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (ReservationConflictException)
            {
                MessageBox.Show("This room is already taken. Please, choice another one.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
