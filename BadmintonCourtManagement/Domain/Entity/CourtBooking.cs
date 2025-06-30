namespace BadmintonCourtManagement.Domain.Entity
{
    public class CourtBooking
    {
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public int CourtId { get; set; }
        public Court Court { get; set; }
    }
}
