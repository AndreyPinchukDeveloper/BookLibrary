using ApplicationClassLibrary.Models;
using BookLibrary.Commands;
using BookLibrary.Services;
using BookLibrary.Stores;
using System;
using System.Windows.Input;

namespace BookLibrary.ViewModels
{
    public class MakeResrvationViewModel:ViewModelBase
    {
        #region TextBoxView
        private string _username;
        public string Username
        {
            get { return _username; }
            set 
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private int _floorNumber;
        public int FloorNumber
        {
            get { return _floorNumber; }
            set
            {
                _floorNumber = value;
                OnPropertyChanged(nameof(FloorNumber));
            }
        }

        private int _roomNumber;
        public int RoomNumber
        {
            get { return _roomNumber; }
            set
            {
                _roomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }

        private DateTime _startDate = new DateTime(2021,1,1);
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private DateTime _endDate = new DateTime(2021,1,8);
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }
        #endregion

        #region Commands
        //TODO -async/await for buttons
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }
        #endregion

        /// <summary>
        /// We initializeour commands in this constructor
        /// </summary>
        public MakeResrvationViewModel(Hotel hotel, MyNavigationService reservationViewNavigationService)
        {
            SubmitCommand = new MakeReservationCommand(this, hotel, reservationViewNavigationService);
            CancelCommand = new NavigateCommand(reservationViewNavigationService);
        }
    }
}
