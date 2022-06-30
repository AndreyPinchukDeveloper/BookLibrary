using ApplicationClassLibrary.Eceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationClassLibrary.Models
{

    public class ReservationBook
    {
        private readonly List<Reservation> _reservations;

        public ReservationBook()
        {
            _reservations = new List<Reservation>();
        }

        /// <summary>
        /// Get the reservation for a user
        /// </summary>
        /// <param name="username"> The username of the user. </param>
        /// <returns></returns>
        public IEnumerable<Reservation> GetReservationsForUser(string username)
        {
            return _reservations.Where(r => r.UserName == username);
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
