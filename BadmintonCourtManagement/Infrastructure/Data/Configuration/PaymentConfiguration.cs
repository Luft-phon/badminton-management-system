using BadmintonCourtManagement.Domain.Entity;
using BadmintonCourtManagement.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection.Emit;

namespace BadmintonCourtManagement.Infrastructure.Data.Configuration
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            // one to one
            builder
                .HasKey(p => p.BookingID); // PK is BookingID

            builder
                .HasOne(b => b.Booking)
                .WithOne(p => p.Payment)
                .HasForeignKey<Payment>(p => p.BookingID); // Shared key

            var paymentMethodConverter = new ValueConverter<PaymentMethod, string>(
     v => v.ToString(),
     v => (PaymentMethod)Enum.Parse(typeof(PaymentMethod), v)
 );

            builder
                .Property(p => p.Method)
                .HasConversion(paymentMethodConverter);

            var paymentStatusConverter = new ValueConverter<PaymentStatus, string>(
  v => v.ToString(),
  v => (PaymentStatus)Enum.Parse(typeof(PaymentStatus), v)
);
            builder
                .Property(p => p.Status)
                .HasConversion(paymentStatusConverter);
        }
    }
}
