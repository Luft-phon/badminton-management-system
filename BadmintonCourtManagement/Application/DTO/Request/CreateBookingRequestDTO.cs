using BadmintonCourtManagement.Domain.Entity;

namespace BadmintonCourtManagement.Application.DTO.Request
{
    public class CreateBookingRequestDTO
    {
        public int UserID { get; set; }
        public DateOnly Date {  get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public ICollection<string> CourtNames { get; set; }

    }
}
