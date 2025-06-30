using BadmintonCourtManagement.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace BadmintonCourtManagement.Domain.Entity
{
    public class User
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Role is required.")]
        public Role Role { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; } = string.Empty;

        public Account Account { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }

        // 1 to many: user booking
        public ICollection<Booking> Bookings { get; set; }

        // 1 to 1: user point
        public Points Points { get; set; }

    }
}
