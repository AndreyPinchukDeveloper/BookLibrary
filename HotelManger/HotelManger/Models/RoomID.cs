namespace HotelManger.Models
{
    public class RoomID
    {
        public int FloorNumber { get; }

        public int RoomNumber { get; }

        public RoomID(int floorNumber, int roomNumber)
        {
            FloorNumber = floorNumber;
            RoomNumber = roomNumber;
        }

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


        public static bool operator ==(RoomID roomID1, RoomID roomID2)
        {
            if (roomID1 is null && roomID2 is null)
            {
                return true;
            }
            return !(roomID1 is null) && roomID1.Equals(roomID2);
        }
        public static bool operator !=(RoomID roomID1, RoomID roomID2)
        {
            return !(roomID1 == roomID2);
        }
    }
}
