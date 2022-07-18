using Microsoft.EntityFrameworkCore;

namespace HotelManagerClassLibrary.Data.DbContexts
{
    public class ReservoomDbContext : DbContext
    {
        //public DbSet<ReservationDTO> Reservations { get; set; }

        public ReservoomDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
