using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BadmintonCourtManagement.Domain.Entity
{
    [Index(nameof(Email))]
    public class Account
    {
        public int UserID { get; set; }
        public string Password { get; set; }
        public DateTime CreateAt { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        public User User { get; set; }
        // 1 to 1: account token
        public Token Token { get; set; }
    }
}
