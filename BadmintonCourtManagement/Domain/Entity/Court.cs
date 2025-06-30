using BadmintonCourtManagement.Domain.Enum;

namespace BadmintonCourtManagement.Domain.Entity
{
    public class Court
    {
        public int CourtID { get; set; }
        public CourtName CourtName { get; set; }
        public CourtStatus CourtStatus { get; set; }
        public double Price { get; set; }

        public ICollection<CourtBooking> courtBookings { get; set; } = new List<CourtBooking>();
    }
}
