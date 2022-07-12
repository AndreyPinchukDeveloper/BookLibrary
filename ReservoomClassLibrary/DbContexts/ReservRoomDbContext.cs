using Microsoft.EntityFrameworkCore;
using ReservoomClassLibrary.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ReservoomClassLibrary.DbContexts
{
    public class ReservRoomDbContext:DbContext
    {
        public DbSet<ReservationDTO> Reservations { get; set; }
    }
}
