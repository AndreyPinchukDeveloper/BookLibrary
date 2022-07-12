using ReservoomClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.ViewModels
{
    /// <summary>
    /// This view model glue the model and the view
    /// </summary>
    public class ReservationViewModel:ViewModelBase
    {
        private readonly Reservation _reservation;
        /// <summary>
        /// We use this ViewModel instead of directly binding with Resrvation model
        /// becase we wouldn't be able to change roomID to a string
        /// </summary>
        public string RoomID => _reservation.RoomID?.ToString();
        public string UserName => _reservation.UserName;
        public string StartDate => _reservation.StartTime.ToString("d");
        public string EndDate => _reservation.EndTime.ToString("d");
        public ReservationViewModel(Reservation reservation)
        {
            _reservation = reservation;
        }
    }
}
