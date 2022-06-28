using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationClassLibrary.Models
{
    public class RoomID
    {
        public int FloorNumber { get; }

        public int RoomNumber { get; }

        public override bool Equals(object obj)
        {
            return obj is RoomID roomID 
                && FloorNumber == roomID.FloorNumber 
                && RoomNumber == roomID.RoomNumber;
        }

        public override string ToString()
        {
            return $"{FloorNumber}{RoomNumber}";
        }
        
        public override int GetHashCode()
        {
            return new { FloorNumber, RoomNumber }.GetHashCode();
        }
    }
}
