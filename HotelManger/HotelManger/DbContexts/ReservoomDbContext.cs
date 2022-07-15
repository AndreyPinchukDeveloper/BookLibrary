using HotelManger.DTOs;
using Microsoft.EntityFrameworkCore;

namespace HotelManger.DbContexts
{
    public class ReservoomDbContext:DbContext
    {
        public DbSet<ReservationDTO> Reservations { get; set; }

        public ReservoomDbContext(DbContextOptions options):base(options)
        {

        }
    }
}
