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
                OnPropertyCHanged(nameof(Username));
            }
        }

        private int _floorNumber;
        public int FloorNumber
        {
            get { return _floorNumber; }
            set
            {
                _floorNumber = value;
                OnPropertyCHanged(nameof(FloorNumber));
            }
        }

        private int _roomNumber;
        public int RoomNumber
        {
            get { return _roomNumber; }
            set
            {
                _roomNumber = value;
                OnPropertyCHanged(nameof(RoomNumber));
            }
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyCHanged(nameof(StartDate));
            }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyCHanged(nameof(EndDate));
            }
        }
        #endregion

        #region Commands
        //TODO - implement command
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }
        #endregion

        public MakeResrvationViewModel()
        {

        }
    }
}
