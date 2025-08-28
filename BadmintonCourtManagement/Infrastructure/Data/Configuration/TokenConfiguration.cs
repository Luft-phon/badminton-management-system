using BadmintonCourtManagement.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BadmintonCourtManagement.Infrastructure.Data.Configuration
{
    public class TokenConfiguration : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            // one to one
            builder
               .HasKey(t => t.UserID);

            builder
                .HasOne(c => c.Account)
                .WithOne(p => p.Token)
                .HasForeignKey<Token>(p => p.UserID);
        }

    }
}
