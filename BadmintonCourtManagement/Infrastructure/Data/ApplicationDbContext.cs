using BadmintonCourtManagement.Domain.Entity;
using BadmintonCourtManagement.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection;

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
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());     
        }
    }
}
