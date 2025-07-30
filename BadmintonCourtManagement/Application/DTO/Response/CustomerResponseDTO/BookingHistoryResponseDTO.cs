namespace BadmintonCourtManagement.Application.DTO.Response.CustomerResponseDTO
{
    public class BookingHistoryResponseDTO
    {
        public int BookingID { get; set; }
        public DateTime BookedDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CourtName { get; set; }
        public string Status { get; set; }
    }
}
