using BadmintonCourtManagement.Domain.Entity;
using BadmintonCourtManagement.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BadmintonCourtManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Court> Courts { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Points> Points { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<CourtBooking> CourtBookings { get; set; }
        public DbSet<Token> Tokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // many to many
            modelBuilder.Entity<CourtBooking>()
                .HasKey(cb => new { cb.BookingId, cb.CourtId }); // Composite PK

            modelBuilder.Entity<CourtBooking>()
                .HasOne(cb => cb.Booking)
                .WithMany(b => b.courtBookings)
                .HasForeignKey(cb => cb.BookingId);

            modelBuilder.Entity<CourtBooking>()
                .HasOne(cb => cb.Court)
                .WithMany(c => c.courtBookings)
                .HasForeignKey(cb => cb.CourtId);


            // one to one
            modelBuilder.Entity<Payment>()
                .HasKey(p => p.BookingID); // PK is BookingID

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Payment)
                .WithOne(p => p.Booking)
                .HasForeignKey<Payment>(p => p.BookingID); // Shared key

            // one to one
            modelBuilder.Entity<Token>()
               .HasKey(t => t.UserID); 

            modelBuilder.Entity<Account>()
                .HasOne(c => c.Token)
                .WithOne(p => p.Account)
                .HasForeignKey<Token>(p => p.UserID); 

            // one to one
            modelBuilder.Entity<Account>()
                .HasKey(a => a.UserID);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Account)
                .WithOne(a => a.User)
                .HasForeignKey<Account>(a => a.UserID);

            // one to one
            modelBuilder.Entity<Points>()
                .HasKey(p => p.UserID);
            modelBuilder.Entity<User>()
                .HasOne(u => u.Points)
                .WithOne(a => a.User)
                .HasForeignKey<Points>(a => a.UserID);

      
            // Mapping (EF top DB) enum to string 
            var roleConverter = new ValueConverter<Role, string>(
       v => v.ToString(), // enum => string
       v => (Role)Enum.Parse(typeof(Role), v) // string => enum
   );
            modelBuilder.Entity<User>()
       .Property(u => u.Role)
       .HasConversion(roleConverter);

            var courtNameConverter = new ValueConverter<CourtName, string>(
       v => v.ToString(), // enum => string
       v => (CourtName)Enum.Parse(typeof(CourtName), v) // string => enum
   );
            modelBuilder.Entity<Court>()
       .Property(u => u.CourtName)
       .HasConversion(courtNameConverter);

            var courtStatusConverter = new ValueConverter<CourtStatus, string>(
       v => v.ToString(), // enum => string
       v => (CourtStatus)Enum.Parse(typeof(CourtStatus), v) // string => enum
   );
            modelBuilder.Entity<Court>()
       .Property(u => u.CourtStatus)
       .HasConversion(courtStatusConverter);

            var paymentStatusConverter = new ValueConverter<PaymentStatus, string>(
      v => v.ToString(),
      v => (PaymentStatus)Enum.Parse(typeof(PaymentStatus), v)
  );
            modelBuilder.Entity<Payment>()
                .Property(p => p.Status)
                .HasConversion(paymentStatusConverter);


            var paymentMethodConverter = new ValueConverter<PaymentMethod, string>(
      v => v.ToString(),
      v => (PaymentMethod)Enum.Parse(typeof(PaymentMethod), v)
  );

            modelBuilder.Entity<Payment>()
                .Property(p => p.Method)
                .HasConversion(paymentMethodConverter);

            var bookingStatusConverter = new ValueConverter<BookingStatus, string>(
      v => v.ToString(),
      v => (BookingStatus)Enum.Parse(typeof(BookingStatus), v)
  );
            modelBuilder.Entity<Booking>()
                .Property(p => p.Status)
                .HasConversion(bookingStatusConverter);
        }
    }
}
