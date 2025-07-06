using System.ComponentModel.DataAnnotations;

namespace BadmintonCourtManagement.Domain.Entity
{
    public class Feedback
    {
        public int FeedbackID { get; set; }
        public string Comments { get; set; }
        public DateTime CreateAt { get; set; }
        [Range(1,5)]
        public int Rating { get; set; }

        // Navigation property to User
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
