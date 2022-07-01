using ApplicationClassLibrary.Eceptions;
using ApplicationClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BookLibrary
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Hotel hotel = new Hotel("Singleton Suites");


            try
            {
                hotel.MakeReservation(new Reservation(
                new RoomID(1, 3),
                "SingletonSean",
                new DateTime(2000, 1, 1),
                new DateTime(2000, 1, 2)
                ));

                hotel.MakeReservation(new Reservation(
                    new RoomID(1, 2),
                    "SingletonSean",
                    new DateTime(2000, 1, 3),
                    new DateTime(2000, 1, 4)
                    ));
            }
            catch (ReservationConflictException exeption)
            {

                throw;
            }

            

            IEnumerable<Reservation> reservations = hotel.GetAllReservations();

            base.OnStartup(e);
        }
    }
}
