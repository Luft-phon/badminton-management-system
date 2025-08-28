using BadmintonCourtManagement.Domain.Entity;
using BadmintonCourtManagement.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection.Emit;

namespace BadmintonCourtManagement.Infrastructure.Data.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            // one to one
            builder
                .HasKey(a => a.UserID);

            builder
                .HasOne(u => u.User)
                .WithOne(a => a.Account)
                .HasForeignKey<Account>(a => a.UserID);

            var accountStatusConverter = new ValueConverter<AccountStatus, string>(
v => v.ToString(), // enum => string
v => (AccountStatus)Enum.Parse(typeof(AccountStatus), v) // string => enum
);
            builder
       .Property(u => u.Status)
       .HasConversion(accountStatusConverter);

            //   builder.HasData(new UserContest
            //   {
            //       ParticipantsId = Guid.Parse("a37b04c6-bd58-48e7-8bab-1bbb207f6216"),
            //       ContestId = Guid.Parse("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
            //       isCreatedPerson = true,
            //       isWinner = false,
            //       Point = 8
            //   },
            //new UserContest
            //{
            //    ParticipantsId = Guid.Parse("26a7cc4e-3f9b-4923-809e-2f9b771d994f"),
            //    ContestId = Guid.Parse("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
            //    isCreatedPerson = false,
            //    isWinner = true,
            //    Point = 10
            //}
        }
    }
}
