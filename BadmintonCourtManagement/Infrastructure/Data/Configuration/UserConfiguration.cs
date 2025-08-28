using BadmintonCourtManagement.Domain.Entity;
using BadmintonCourtManagement.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection.Emit;

namespace BadmintonCourtManagement.Infrastructure.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Mapping (EF top DB) enum to string 
            var roleConverter = new ValueConverter<Role, string>(
       v => v.ToString(), // enum => string
       v => (Role)Enum.Parse(typeof(Role), v) // string => enum
   );
            builder
       .Property(u => u.Role)
       .HasConversion(roleConverter);
        }
    }
}
