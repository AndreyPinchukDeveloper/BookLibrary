using HotelManagerClassLibrary.Models;
using System.Threading.Tasks;

namespace HotelManger.Services.ReservationCreators
{
    public interface IReservationCreator
    {
        Task CreateReservation(Reservation reservation);
    }
}
