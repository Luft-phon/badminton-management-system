namespace BadmintonCourtManagement.Application.DTO.Response.CourtResponseDTO
{
    public class GetCourtResponseDTO
    {
        public int CourtID { get; set; }
        public string CourtName { get; set; }
        public string CourtStatus { get; set; }
        public string? Next_booking_date { get; set; }
        public string? Next_booking_hour { get; set; }
    }
}
