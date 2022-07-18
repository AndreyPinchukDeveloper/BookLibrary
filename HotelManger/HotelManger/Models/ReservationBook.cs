using HotelManger.Exceptions;
using HotelManger.Services.ReservationConflictValidators;
using HotelManger.Services.ReservationCreators;
using HotelManger.Services.ReservationProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManger.Models
{
    public class ReservationBook
    {
        private readonly IReservationProvider _reservationProvider;
        private readonly IReservationCreator _reservationCreator;
        private readonly IReservationConflictValidator _reservationConflictValidator;

        public ReservationBook(IReservationProvider reservationProvider, IReservationCreator reservationCreator, IReservationConflictValidator reservationConflictValidator)
        {
            _reservationProvider = reservationProvider;
            _reservationCreator = reservationCreator;
            _reservationConflictValidator = reservationConflictValidator;
        }

        /// <summary>
        /// Get all reservations
        /// </summary>
        /// <param name="username"> The username of the user. </param>
        /// <returns></returns>
        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _reservationProvider.GetAllReservations();
        }

        /// <summary>
        /// Make a new reservation
        /// </summary>
        /// <param name="reservation"> The incoming reservation. </param>
        /// <exception cref="ReservationConflictException"></exception>
        public async Task AddReservation(Reservation reservation)
        {
            Reservation conflictReservation = await _reservationConflictValidator.GetConflictReservation(reservation);

            if (conflictReservation != null)
            {
                throw new ReservationConflictException(conflictReservation, reservation);
            }
            await _reservationCreator.CreateReservation(reservation);
        }
    }
}
