using System;
using System.ComponentModel.DataAnnotations;

namespace HotelManger.DTOs
{
    public class ReservationDTO
    {
        [Key]
        public Guid Id { get; set; }//GUID — это 128-разрядное целое число (16 байт), которое можно использовать
                                    //во всех компьютерах и сетях, где требуется уникальный идентификатор.
                                    //Такой идентификатор имеет очень низкую вероятность дублирования
        public int FloorNumber { get; set; }
        public int RoomNumber { get; set; }
        public string UserName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
