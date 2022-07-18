using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManger.Models
{
    public class Hotel
    {
        private readonly ReservationBook _reservationBook;
        public string Name { get; }

        public Hotel(string name, ReservationBook reservationBook)
        {
            _reservationBook = reservationBook;
            Name = name;
        }

        /// <summary>
        /// Get all reservations
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>The resrvation for the user.</returns>
        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _reservationBook.GetAllReservations();
        }

        /// <summary>
        /// Make a reservation.
        /// </summary>
        /// <param name="reservation">The incoming resrvation.</param>
        /// <exception cref="ReservationConflictEception"
        public async Task MakeReservation(Reservation reservation)
        {
            await _reservationBook.AddReservation(reservation);
        }
    }
}
