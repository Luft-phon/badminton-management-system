using BadmintonCourtManagement.Domain.Entity;
using BadmintonCourtManagement.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BadmintonCourtManagement.Infrastructure.Data.Configuration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            var bookingStatusConverter = new ValueConverter<BookingStatus, string>(
      v => v.ToString(),
      v => (BookingStatus)Enum.Parse(typeof(BookingStatus), v)
  );
            builder
                .Property(p => p.Status)
                .HasConversion(bookingStatusConverter);
        }
    }
}
