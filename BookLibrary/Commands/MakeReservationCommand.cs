using ApplicationClassLibrary.Eceptions;
using ApplicationClassLibrary.Models;
using BookLibrary.ViewModels;
using System;
using System.Collections.Generic;
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
