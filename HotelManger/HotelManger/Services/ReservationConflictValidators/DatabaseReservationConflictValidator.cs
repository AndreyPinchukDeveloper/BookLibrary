using HotelManger.DbContexts;
using HotelManger.DTOs;
using HotelManger.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManger.Services.ReservationConflictValidators
{
    internal class DatabaseReservationConflictValidator : IReservationConflictValidator
    {
        private readonly ReservoomDbContextFactory _dbContextFactory;

        public DatabaseReservationConflictValidator(ReservoomDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Reservation> GetConflictReservation(Reservation reservation)
        {
            using (ReservoomDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Reservations
                    .Select(r => ToReservation(r))
                    .FirstOrDefaultAsync(r => r.Conflicts(reservation));
            }
        }

        private Reservation ToReservation(ReservationDTO dto)
        {
            return new Reservation(new RoomID(dto.FloorNumber, dto.RoomNumber), dto.UserName, dto.StartTime, dto.EndTime);
        }
    }
}
