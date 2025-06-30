namespace BadmintonCourtManagement.Domain.Entity
{
    public class Account
    {
        public int UserID { get; set; }
        public string Password { get; set; }
        public DateTime CreateAt { get; set; }
        public User User { get; set; }
    }
}
