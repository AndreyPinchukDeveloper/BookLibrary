using HotelManagerClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManger.Services.ReservationProviders
{
    public class DatabaseReservationProvider : IReservationProvider
    {
        public Task<IEnumerable<Reservation>> GetAllReservation()
        {
            throw new NotImplementedException();
        }
    }
}
