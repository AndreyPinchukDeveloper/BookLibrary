using HotelManagerClassLibrary.Data.Services.ReservationProviders;
using HotelManagerClassLibrary.Exceptions;

namespace HotelManagerClassLibrary.Models
{
    public class ReservationBook
    {
        private readonly IReservationProvider _reservationProvider;

        public ReservationBook()
        {
            _reservations = new List<Reservation>();
        }

        /// <summary>
        /// Get all reservations
        /// </summary>
        /// <param name="username"> The username of the user. </param>
        /// <returns></returns>
        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservations;
        }

        /// <summary>
        /// Make a new reservation
        /// </summary>
        /// <param name="reservation"> The incoming reservation. </param>
        /// <exception cref="ReservationConflictException"></exception>
        public void AddReservation(Reservation reservation)
        {
            foreach (Reservation existingReservation in _reservations)//cheking if the reservation already exist
            {
                if (existingReservation.Conflicts(reservation))
                {
                    throw new ReservationConflictException(existingReservation, reservation);
                }
            }
            _reservations.Add(reservation);
        }
    }
}
