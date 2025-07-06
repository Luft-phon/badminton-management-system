namespace BadmintonCourtManagement.Application.DTO.Response.BookingResponseDTO
{
    public class CreateBookingResponseDTO
    {
        public int Status { get; set; }
        public string Messege { get; set; }
        public int UserID { get; set; }
        public DateOnly Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public ICollection<string> CourtNames { get; set; }
    }
}
