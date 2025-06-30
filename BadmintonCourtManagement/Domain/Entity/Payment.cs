using BadmintonCourtManagement.Domain.Enum;

namespace BadmintonCourtManagement.Domain.Entity
{
    public class Payment
    {
        public int BookingID { get; set; }     // share PK to Booking
        public DateTime PaidAt { get; set; }
        public PaymentStatus Status { get; set; }
        public double Amount { get; set; }
        public PaymentMethod Method { get; set; }
        public Booking Booking { get; set; }
    }
}
