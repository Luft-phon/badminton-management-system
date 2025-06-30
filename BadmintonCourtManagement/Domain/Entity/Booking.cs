using BadmintonCourtManagement.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace BadmintonCourtManagement.Domain.Entity
{
    public class Booking : IValidatableObject
    {
        public int BookingID { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double TotalHourBooked { get; set; }
        public BookingStatus Status { get; set; }

        // 1 to many: user booking
        public User User { get; set; }

        // many to many: booking court
        public ICollection<CourtBooking> courtBookings { get; set; } = new List<CourtBooking>();
        public Payment Payment { get; set; }

        //Validation to store in ModelState
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if ((EndTime - StartTime).TotalHours < 1)
            {
                yield return new ValidationResult("Customer need to book at least 1 hour", new[] { nameof(EndTime) });  //specific in Endtime
            }
            if (EndTime < StartTime)
            {
                yield return new ValidationResult("End time must be after start time", new[] {nameof(EndTime) });
            }
        }
    }
}
