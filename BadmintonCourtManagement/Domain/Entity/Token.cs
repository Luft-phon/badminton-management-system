namespace BadmintonCourtManagement.Domain.Entity
{
    public class Token
    {
        public int UserID { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime? RevokedAt { get; set; }
        public Account Account { get; set; } 
    }
}
