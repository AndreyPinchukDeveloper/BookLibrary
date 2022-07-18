using HotelManagerClassLibrary.Models;

namespace HotelManagerClassLibrary.Data.Services.ReservationCreators
{
    public interface IReservationCreator
    {
        Task CreateReservation(Reservation reservation);
    }
}
