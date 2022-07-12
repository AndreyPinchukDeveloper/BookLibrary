using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservoomClassLibrary.Models
{
    public class Hotel
    {
        private readonly ReservationBook _reservationBook;
        public string Name { get;}  
        
        public Hotel(string name)
        {
            _reservationBook = new ReservationBook();
            Name = name;
        }

        /// <summary>
        /// Get all reservations
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>The resrvation for the user.</returns>
        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservationBook.GetAllReservations();
        }

        /// <summary>
        /// Make a reservation.
        /// </summary>
        /// <param name="reservation">The incoming resrvation.</param>
        /// <exception cref="ReservationConflictEception"
        public void MakeReservation(Reservation reservation)
        {
            _reservationBook.AddReservation(reservation);
        }
    }
}
