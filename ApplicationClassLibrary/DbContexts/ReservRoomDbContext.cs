using ApplicationClassLibrary.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApplicationClassLibrary.DbContexts
{
    public class ReservRoomDbContext:DbContext
    {
        public DbSet<ReservationDTO> Reservations { get; set; }
    }
}
