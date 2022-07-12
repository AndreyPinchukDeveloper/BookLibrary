using ReservoomClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReservoomClassLibrary.Eceptions
{
    public class ReservationConflictException : Exception
    {
        public Reservation ExistingReservation { get; }
        public Reservation IncomeResrvation { get; }

        public ReservationConflictException(Reservation existingReservation = null, Reservation incomeResrvation = null)
        {
            ExistingReservation = existingReservation;
            IncomeResrvation = incomeResrvation;
        }

        public ReservationConflictException(string message, Reservation existingReservation, Reservation incomeResrvation) : base(message)
        {
            ExistingReservation = existingReservation;
            IncomeResrvation = incomeResrvation;
        }

        public ReservationConflictException(string message, Exception innerException, Reservation existingReservation, Reservation incomeResrvation) : base(message, innerException)
        {
            ExistingReservation = existingReservation;
            IncomeResrvation = incomeResrvation;
        }

        protected ReservationConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
