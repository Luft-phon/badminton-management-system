using BadmintonCourtManagement.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BadmintonCourtManagement.Infrastructure.Data.Configuration
{
    public class PointConfiguration : IEntityTypeConfiguration<Points>
    {
        public void Configure(EntityTypeBuilder<Points> builder)
        {
            // one to one
            builder
                .HasKey(p => p.UserID);
            builder
                .HasOne(u => u.User)
                .WithOne(a => a.Points)
                .HasForeignKey<Points>(a => a.UserID);
        }
    }
}
