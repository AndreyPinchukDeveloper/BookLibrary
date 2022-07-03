using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationClassLibrary.Models
{
    public class Reservation
    {
        public RoomID RoomID { get;}
        public string UserName { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        /// <summary>
        /// Time of reservation
        /// </summary>
        public TimeSpan Length => EndTime.Subtract(StartTime);

        public Reservation(RoomID roomID, string userName, DateTime startTime, DateTime endTime)
        {
            RoomID = roomID;
            UserName = userName;
            StartTime = startTime;
            EndTime = endTime;
        }

        /// <summary>
        /// While we're going to create new reservation this method check if our reservation already exist
        /// </summary>
        internal bool Conflicts(Reservation reservation)
        {
            if (reservation.RoomID != RoomID)
            {
                return false;
            }

            return reservation.StartTime < EndTime && reservation.EndTime > StartTime;
        }
    }
}
