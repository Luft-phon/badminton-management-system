using BadmintonCourtManagement.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BadmintonCourtManagement.Infrastructure.Data.Configuration
{
    public class CourtBookingsConfiguration : IEntityTypeConfiguration<CourtBooking>
    {
        public void Configure(EntityTypeBuilder<CourtBooking> builder)
        {
            // many to many
            builder
                .HasKey(cb => new { cb.BookingId, cb.CourtId }); // Composite PK

            builder
                .HasOne(cb => cb.Booking)
                .WithMany(b => b.courtBookings)
                .HasForeignKey(cb => cb.BookingId);

            builder
                .HasOne(cb => cb.Court)
                .WithMany(c => c.courtBookings)
                .HasForeignKey(cb => cb.CourtId);
        }
    }
}
