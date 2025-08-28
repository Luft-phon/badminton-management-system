using BadmintonCourtManagement.Domain.Entity;
using BadmintonCourtManagement.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection.Emit;

namespace BadmintonCourtManagement.Infrastructure.Data.Configuration
{
    public class CourtConfiguration : IEntityTypeConfiguration<Court>
    {
        public void Configure(EntityTypeBuilder<Court> builder) {

            var courtNameConverter = new ValueConverter<CourtName, string>(
v => v.ToString(), // enum => string
v => (CourtName)Enum.Parse(typeof(CourtName), v) // string => enum
);
            builder
       .Property(u => u.CourtName)
       .HasConversion(courtNameConverter);

            var courtStatusConverter = new ValueConverter<CourtStatus, string>(
       v => v.ToString(), // enum => string
       v => (CourtStatus)Enum.Parse(typeof(CourtStatus), v) // string => enum
   );
            builder
       .Property(u => u.CourtStatus)
       .HasConversion(courtStatusConverter);
        }
    }
}
