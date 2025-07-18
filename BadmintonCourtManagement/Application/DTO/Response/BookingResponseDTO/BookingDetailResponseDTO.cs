namespace BadmintonCourtManagement.Application.DTO.Response.BookingResponseDTO
{
    public class BookingDetailResponseDTO
    {
        public int Name { get; set; }
        public string Phone { get; set; }
        public int BookingID { get; set; }
        public string CourtName { get; set; }
        public string BookingStatus { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public double PaymentAmount { get; set; }
        public string PaymentStatus { get; set; }
        public string CreateDate { get; set; }
        public string BookingDate { get; set; }
    }
}
