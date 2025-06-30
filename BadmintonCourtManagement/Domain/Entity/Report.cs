namespace BadmintonCourtManagement.Domain.Entity
{
    public class Report
    {
        public int ReportID { get; set; }
        public DateTime CreateAt { get; set; }
        public int TotalFreeHour { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
