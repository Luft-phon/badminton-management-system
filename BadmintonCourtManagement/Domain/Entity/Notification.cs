namespace BadmintonCourtManagement.Domain.Entity
{
    public class Notification
    {
        public int NotificationID { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public ICollection<User> Users { get; set; } =new List<User>();
    }
}
