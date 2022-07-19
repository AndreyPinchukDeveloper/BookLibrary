using HotelManagerClassLibrary.Data.DbContexts;
using HotelManagerClassLibrary.Data.DTOs;
using HotelManagerClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagerClassLibrary.Data.Services.ReservationProviders
{
    public class DatabaseReservationProvider : IReservationProvider
    {
        private readonly ReservoomDbContextFactory _dbContextFactory;

        public DatabaseReservationProvider(ReservoomDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

       public async Task<IEnumerable<Reservation>> GetAllReservations()//Класс Task представляет собой одну операцию, которая не возвращает значение и обычно выполняется асинхронно.
                                                                        //Task объекты являются одним из центральных компонентов асинхронного шаблона на основе задач
        {
            using (ReservoomDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<ReservationDTO> reservationDTOs = await context.Reservations.ToListAsync();
                return reservationDTOs.Select(r => ToReservation(r));
            }
        }

        private static Reservation ToReservation(ReservationDTO dto)
        {
            return new Reservation(new RoomID(dto.FloorNumber, dto.RoomNumber), dto.UserName, dto.StartTime, dto.EndTime);
        }
    }
}
