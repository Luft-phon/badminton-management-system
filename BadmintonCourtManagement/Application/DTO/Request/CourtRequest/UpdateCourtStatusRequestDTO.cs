namespace BadmintonCourtManagement.Application.DTO.Request.CourtRequest
{
    public class UpdateCourtStatusRequestDTO
    {
        public int CourtID { get; set; }
        public string CourtStatus { get; set; } // e.g., "Available", "Booked", "Under Maintenance"
    }
}
