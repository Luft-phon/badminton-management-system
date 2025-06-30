using BadmintonCourtManagement.Domain.Enum;

namespace BadmintonCourtManagement.Domain.Entity
{
    public class Points
    {
        public int UserID { get; set; }
        public int Point {  get; set; }
        public DateTime ClaimDate { get; set; }
        public int TotalRedeem { get; set; }
        public PointStatus Status { get; set; }
        public User User { get; set; }
    }
}
