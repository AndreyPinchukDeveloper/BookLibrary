using HotelManger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManger.Stores
{
    public class HotelStore
    {
        private readonly Hotel _hotel;
        private readonly List<Reservation> _reservations;

        public IEnumerable<Reservation> Reservations => _reservations;
        public HotelStore(Hotel hotel)
        {
            _hotel = hotel;
            _reservations = new List<Reservation>();
        }

        public async Task Load()
        {
            IEnumerable<Reservation> reservations = await _hotel.GetAllReservations();

            _reservations.Clear();
            _reservations.AddRange(reservations);
        }
    }
}
