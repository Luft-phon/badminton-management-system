//using BadmintonCourtManagement.Domain.Entity;
//using BadmintonCourtManagement.Domain.Enum;
//using BadmintonCourtManagement.Infrastructure.Data;
//using System.Drawing;

//namespace BadmintonCourtManagement.Infrastructure.Testing
//{
//    public class SeedData
//    {
//        public static void Initialize(IServiceProvider service)    //IserviceProvider is used to resolve dependencies
//        {
//            using var scope = service.CreateScope();    // tạo Scope(vòng đời) để inject các Request bên ngoài như SeedData, using để tự động dispose vòng đời của scope khi kết thúc
//            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//            var logger = scope.ServiceProvider.GetRequiredService<ILogger<SeedData>>();
//            logger.LogInformation("Using DB Provider: {provider}", context.Database.ProviderName);

//            context.Database.EnsureDeleted();
//            //context.Database.EnsureCreated();

//            if (!context.Reports.Any())
//            {
//                context.Reports.AddRange(
//                    new Report { ReportID = 1, CreateAt = new DateTime(2025, 6, 1), TotalFreeHour = 2 },
//                    new Report { ReportID = 2, CreateAt = new DateTime(2025, 6, 1), TotalFreeHour = 1 }
//                );
//                context.SaveChanges();
//            }

//            if (!context.User.Any())
//            {
//                context.User.AddRange(
//                   new User { UserID = 1, FirstName = "Alice", LastName = "Nguyen", Email = "alice@example.com", Role = Domain.Enum.Role.Staff, Dob = new DateOnly(1995, 6, 15), Phone = "0123456789" },
//                     new User { UserID = 2, FirstName = "Phong", LastName = "Ngo", Email = "bob@example.com", Role = Domain.Enum.Role.Owner, Dob = new DateOnly(1990, 1, 20), Phone = "0987654321" },
//                     new User { UserID = 3, FirstName = "Tuann", LastName = "NgoTran", Email = "bob@example.com", Role = Domain.Enum.Role.Member, Dob = new DateOnly(1990, 1, 20), Phone = "0987654321" },
//                     new User { UserID = 4, FirstName = "Thao", LastName = "Ngo", Email = "alice@example.com", Role = Domain.Enum.Role.Staff, Dob = new DateOnly(1995, 6, 15), Phone = "0123456789" },
//                     new User { UserID = 5, FirstName = "Huy", LastName = "Nguyen", Email = "bob@example.com", Role = Domain.Enum.Role.Owner, Dob = new DateOnly(1990, 1, 20), Phone = "0987654321" },
//                     new User { UserID = 6, FirstName = "Quan", LastName = "Ngo", Email = "bob@example.com", Role = Domain.Enum.Role.Member, Dob = new DateOnly(1990, 1, 20), Phone = "0987654321" },
//                     new User { UserID = 7, FirstName = "Nam", LastName = "Tran", Email = "nam1@example.com", Role = Domain.Enum.Role.Member, Dob = new DateOnly(1992, 3, 1), Phone = "0912345671" },
//                     new User { UserID = 8, FirstName = "Linh", LastName = "Le", Email = "linh2@example.com", Role = Domain.Enum.Role.Member, Dob = new DateOnly(1994, 7, 12), Phone = "0912345672" },
//                     new User { UserID = 9, FirstName = "Khoa", LastName = "Pham", Email = "khoa3@example.com", Role = Domain.Enum.Role.Member, Dob = new DateOnly(1990, 11, 23), Phone = "0912345673" },
//                     new User { UserID = 10, FirstName = "Mai", LastName = "Phuong", Email = "hello@gmail.com", Role = Domain.Enum.Role.Member, Dob = new DateOnly(2025, 6, 30), Phone = "0912345674" },
//                     new User { UserID = 11, FirstName = "Son", LastName = "Hoang", Email = "son5@example.com", Role = Domain.Enum.Role.Member, Dob = new DateOnly(1993, 4, 5), Phone = "0912345675" },
//                     new User { UserID = 12, FirstName = "Lan", LastName = "Doan", Email = "lan6@example.com", Role = Domain.Enum.Role.Member, Dob = new DateOnly(1991, 8, 25), Phone = "0912345676" },
//                     new User { UserID = 13, FirstName = "Duy", LastName = "Dang", Email = "duy7@example.com", Role = Domain.Enum.Role.Member, Dob = new DateOnly(1995, 2, 10), Phone = "0912345677" },
//                     new User { UserID = 14, FirstName = "Ha", LastName = "Nguyen", Email = "ha8@example.com", Role = Domain.Enum.Role.Member, Dob = new DateOnly(1989, 12, 30), Phone = "0912345678" },
//                     new User { UserID = 15, FirstName = "Trang", LastName = "Phan", Email = "trang9@example.com", Role = Domain.Enum.Role.Member, Dob = new DateOnly(1997, 1, 9), Phone = "0912345679" },
//                     new User { UserID = 16, FirstName = "Minh", LastName = "Vo", Email = "minh10@example.com", Role = Domain.Enum.Role.Member, Dob = new DateOnly(1998, 5, 14), Phone = "0912345680" }
//                );
//                context.SaveChanges();
//            }

//            if (!context.Bookings.Any())
//            {
//                context.Bookings.AddRange(
//      new Booking { BookingID = 1, StartTime = new DateTime(2025, 6, 25, 9, 0, 0), EndTime = new DateTime(2025, 6, 25, 11, 0, 0), TotalHourBooked = 2, ReportID = 1, UserID = 6, Status = BookingStatus.Booked, BookingDate = new DateTime(2025, 6, 25, 8, 0, 0) },
//      new Booking { BookingID = 2, StartTime = new DateTime(2025, 6, 26, 14, 0, 0), EndTime = new DateTime(2025, 6, 26, 16, 0, 0), TotalHourBooked = 2, ReportID = 2, UserID = 6, Status = BookingStatus.Booked, BookingDate = new DateTime(2025, 6, 26, 13, 0, 0) },
//      new Booking { BookingID = 3, StartTime = new DateTime(2025, 6, 27, 15, 0, 0), EndTime = new DateTime(2025, 6, 27, 16, 0, 0), TotalHourBooked = 1, ReportID = null, UserID = 3, Status = BookingStatus.Booked, BookingDate = new DateTime(2025, 6, 27, 14, 0, 0) },
//      new Booking { BookingID = 4, StartTime = new DateTime(2025, 6, 29, 15, 0, 0), EndTime = new DateTime(2025, 6, 29, 16, 0, 0), TotalHourBooked = 1, ReportID = null, UserID = 3, Status = BookingStatus.Booked, BookingDate = new DateTime(2025, 6, 29, 14, 0, 0) },
//      new Booking { BookingID = 6, StartTime = new DateTime(2025, 6, 29, 8, 0, 0), EndTime = new DateTime(2025, 6, 29, 10, 0, 0), TotalHourBooked = 2, ReportID = null, UserID = 6, Status = BookingStatus.Booked, BookingDate = new DateTime(2025, 6, 29, 7, 0, 0) },
//      new Booking { BookingID = 7, StartTime = new DateTime(2025, 6, 30, 8, 0, 0), EndTime = new DateTime(2025, 6, 30, 10, 0, 0), TotalHourBooked = 2, ReportID = null, UserID = 7, Status = BookingStatus.Booked, BookingDate = new DateTime(2025, 6, 30, 7, 0, 0) },
//      new Booking { BookingID = 8, StartTime = new DateTime(2025, 6, 30, 10, 0, 0), EndTime = new DateTime(2025, 6, 30, 11, 0, 0), TotalHourBooked = 1, ReportID = null, UserID = 8, Status = BookingStatus.Booked, BookingDate = new DateTime(2025, 6, 30, 9, 0, 0) },
//      new Booking { BookingID = 9, StartTime = new DateTime(2025, 6, 30, 12, 0, 0), EndTime = new DateTime(2025, 6, 30, 14, 0, 0), TotalHourBooked = 2, ReportID = null, UserID = 9, Status = BookingStatus.Booked, BookingDate = new DateTime(2025, 6, 30, 11, 0, 0) },
//      new Booking { BookingID = 10, StartTime = new DateTime(2025, 6, 30, 14, 0, 0), EndTime = new DateTime(2025, 6, 30, 15, 0, 0), TotalHourBooked = 1, ReportID = null, UserID = 10, Status = BookingStatus.Booked, BookingDate = new DateTime(2025, 6, 30, 13, 0, 0) },
//      new Booking { BookingID = 11, StartTime = new DateTime(2025, 6, 30, 15, 0, 0), EndTime = new DateTime(2025, 6, 30, 16, 0, 0), TotalHourBooked = 1, ReportID = null, UserID = 11, Status = BookingStatus.Booked, BookingDate = new DateTime(2025, 6, 30, 14, 0, 0) },
//      new Booking { BookingID = 12, StartTime = new DateTime(2025, 6, 30, 16, 0, 0), EndTime = new DateTime(2025, 6, 30, 18, 0, 0), TotalHourBooked = 2, ReportID = null, UserID = 12, Status = BookingStatus.Booked, BookingDate = new DateTime(2025, 6, 30, 15, 0, 0) },
//      new Booking { BookingID = 13, StartTime = new DateTime(2025, 7, 1, 8, 0, 0), EndTime = new DateTime(2025, 7, 1, 10, 0, 0), TotalHourBooked = 2, ReportID = null, UserID = 13, Status = BookingStatus.Booked, BookingDate = new DateTime(2025, 7, 1, 7, 0, 0) },
//      new Booking { BookingID = 14, StartTime = new DateTime(2025, 7, 1, 10, 0, 0), EndTime = new DateTime(2025, 7, 1, 11, 0, 0), TotalHourBooked = 1, ReportID = null, UserID = 14, Status = BookingStatus.Booked, BookingDate = new DateTime(2025, 7, 1, 9, 0, 0) },
//      new Booking { BookingID = 15, StartTime = new DateTime(2025, 7, 1, 12, 0, 0), EndTime = new DateTime(2025, 7, 1, 14, 0, 0), TotalHourBooked = 2, ReportID = null, UserID = 15, Status = BookingStatus.Booked, BookingDate = new DateTime(2025, 7, 1, 11, 0, 0) },
//      new Booking { BookingID = 16, StartTime = new DateTime(2025, 7, 1, 15, 0, 0), EndTime = new DateTime(2025, 7, 1, 17, 0, 0), TotalHourBooked = 2, ReportID = null, UserID = 16, Status = BookingStatus.Booked, BookingDate = new DateTime(2025, 7, 1, 14, 0, 0) }
//  );
//                context.SaveChanges();
//            }

//            if (!context.Account.Any())
//            {
//                context.Account.AddRange(
//                    new Account { UserID = 1, Password = "password123", CreateAt = new DateTime(2024, 1, 1) },
//                    new Account { UserID = 2, Password = "adminpass", CreateAt = new DateTime(2024, 2, 1) }
//                );
//                context.SaveChanges();
//            }

//            if (!context.Feedback.Any())
//            {
//                context.Feedback.AddRange(
//       new Feedback { FeedbackID = 1, Comments = "Great experience!", CreateAt = new DateTime(2025, 6, 25, 12, 0, 0), Rating = 5, UserID = 1 },
//       new Feedback { FeedbackID = 2, Comments = "Court could be cleaner.", CreateAt = new DateTime(2025, 6, 26, 17, 0, 0), Rating = 3, UserID = 2 },
//       new Feedback { FeedbackID = 3, Comments = "Great experience!", CreateAt = new DateTime(2025, 6, 25, 12, 0, 0), Rating = 5, UserID = 1 },
//       new Feedback { FeedbackID = 4, Comments = "Court could be cleaner.", CreateAt = new DateTime(2025, 6, 26, 17, 0, 0), Rating = 3, UserID = 2 }
//   );
//                context.SaveChanges();
//            }

//            if (!context.Points.Any())
//            {
//                context.Points.AddRange(
//      new Points { UserID = 3, Point = 50, ClaimDate = new DateTime(2025, 6, 1), TotalRedeem = 10, Status = Domain.Enum.PointStatus.Pending },
//      new Points { UserID = 6, Point = 70, ClaimDate = new DateTime(2025, 6, 15), TotalRedeem = 20, Status = Domain.Enum.PointStatus.Pending },
//      new Points { UserID = 7, Point = 0, ClaimDate = null, TotalRedeem = 0, Status =  Domain.Enum.PointStatus.Pending},
//      new Points { UserID = 8, Point = 0, ClaimDate = null, TotalRedeem = 0, Status = Domain.Enum.PointStatus.Pending },
//      new Points { UserID = 9, Point = 0, ClaimDate = null, TotalRedeem = 0, Status = Domain.Enum.PointStatus.Pending },
//      new Points { UserID = 10, Point = 0, ClaimDate = null, TotalRedeem = 0, Status = Domain.Enum.PointStatus.Pending },
//      new Points { UserID = 11, Point = 0, ClaimDate = null, TotalRedeem = 0, Status =  Domain.Enum.PointStatus.Pending },        
//      new Points { UserID = 12, Point = 0, ClaimDate = null, TotalRedeem = 0, Status = Domain.Enum.PointStatus.Pending },
//      new Points { UserID = 13, Point = 0, ClaimDate = null, TotalRedeem = 0, Status = Domain.Enum.PointStatus.Pending },
//      new Points { UserID = 14, Point = 0, ClaimDate = null, TotalRedeem = 0, Status = Domain.Enum.PointStatus.Pending },
//      new Points { UserID = 15, Point = 0, ClaimDate = null, TotalRedeem = 0, Status = Domain.Enum.PointStatus.Pending },
//      new Points { UserID = 16, Point = 0, ClaimDate = null, TotalRedeem = 0, Status = Domain.Enum.PointStatus.Pending }
//  );
//                context.SaveChanges();
//            }

//            if (!context.Payments.Any())
//            {
//                context.Payments.AddRange(
//                      new Payment { BookingID = 1, PaidAt = new DateTime(2025, 6, 25, 9, 0, 0), Status = Domain.Enum.PaymentStatus.Complete, Amount = 40, Method = Domain.Enum.PaymentMethod.Cash },
//                      new Payment { BookingID = 2, PaidAt = null, Status = Domain.Enum.PaymentStatus.Uncomplete, Amount = 80, Method = null },
//                      new Payment { BookingID = 3, PaidAt = new DateTime(2025, 6, 27, 9, 0, 0), Status = Domain.Enum.PaymentStatus.Complete, Amount = 40, Method = Domain.Enum.PaymentMethod.Cash },
//                      new Payment { BookingID = 4, PaidAt = new DateTime(2025, 6, 29, 16, 0, 0), Status = Domain.Enum.PaymentStatus.Complete, Amount = 40, Method = Domain.Enum.PaymentMethod.Cash },
//                      new Payment { BookingID = 6, PaidAt = new DateTime(2025, 6, 29, 8, 0, 0), Status = Domain.Enum.PaymentStatus.Complete, Amount = 80, Method = Domain.Enum.PaymentMethod.Card },
//                      new Payment { BookingID = 7, PaidAt = new DateTime(2025, 6, 30, 10, 0, 0), Status = Domain.Enum.PaymentStatus.Complete, Amount = 80, Method = Domain.Enum.PaymentMethod.Card },
//                      new Payment { BookingID = 8, PaidAt = new DateTime(2025, 6, 30, 12, 0, 0), Status = Domain.Enum.PaymentStatus.Complete, Amount = 40, Method = Domain.Enum.PaymentMethod.Cash },
//                      new Payment { BookingID = 9, PaidAt = new DateTime(2025, 6, 30, 14, 0, 0), Status = Domain.Enum.PaymentStatus.Complete, Amount = 80, Method = Domain.Enum.PaymentMethod.Cash },
//                      new Payment { BookingID = 10, PaidAt = new DateTime(2025, 6, 30, 16, 0, 0), Status = Domain.Enum.PaymentStatus.Complete, Amount = 40, Method = Domain.Enum.PaymentMethod.Cash },
//                      new Payment { BookingID = 11, PaidAt = new DateTime(2025, 6, 30, 18, 0, 0), Status = Domain.Enum.PaymentStatus.Complete, Amount = 40, Method = Domain.Enum.PaymentMethod.Card },
//                      new Payment { BookingID = 12, PaidAt = new DateTime(2025, 7, 1, 8, 0, 0), Status = Domain.Enum.PaymentStatus.Complete, Amount = 80, Method = Domain.Enum.PaymentMethod.Card },
//                      new Payment { BookingID = 13, PaidAt = new DateTime(2025, 7, 1, 10, 0, 0), Status = Domain.Enum.PaymentStatus.Complete, Amount = 80, Method = Domain.Enum.PaymentMethod.Cash },
//                      new Payment { BookingID = 14, PaidAt = new DateTime(2025, 7, 1, 12, 0, 0), Status = Domain.Enum.PaymentStatus.Complete, Amount = 40, Method = Domain.Enum.PaymentMethod.Cash },
//                      new Payment { BookingID = 15, PaidAt = new DateTime(2025, 7, 1, 15, 0, 0), Status = Domain.Enum.PaymentStatus.Complete, Amount = 80, Method = Domain.Enum.PaymentMethod.Cash },
//                      new Payment { BookingID = 16, PaidAt = new DateTime(2025, 7, 1, 17, 0, 0), Status = Domain.Enum.PaymentStatus.Complete, Amount = 80, Method = Domain.Enum.PaymentMethod.Card }
//                  ); context.SaveChanges();
//            }

//            if (!context.Courts.Any())
//            {
//                context.Courts.AddRange(
//        new Court { CourtID = 1, CourtName = Domain.Enum.CourtName.Court1, CourtStatus = Domain.Enum.CourtStatus.Available, Price = 40 },
//        new Court { CourtID = 2, CourtName = Domain.Enum.CourtName.Court2, CourtStatus = Domain.Enum.CourtStatus.Available, Price = 40 },
//        new Court { CourtID = 3, CourtName = Domain.Enum.CourtName.Court3, CourtStatus = Domain.Enum.CourtStatus.Available, Price = 40 },
//        new Court { CourtID = 4, CourtName = Domain.Enum.CourtName.Court4, CourtStatus = Domain.Enum.CourtStatus.Available, Price = 40 },
//        new Court { CourtID = 5, CourtName = Domain.Enum.CourtName.Court5, CourtStatus = Domain.Enum.CourtStatus.Available, Price = 40 },
//        new Court { CourtID = 6, CourtName = Domain.Enum.CourtName.Court6, CourtStatus = Domain.Enum.CourtStatus.Available, Price = 40 },
//        new Court { CourtID = 7, CourtName = Domain.Enum.CourtName.Court7, CourtStatus = Domain.Enum.CourtStatus.Available, Price = 40 },
//        new Court { CourtID = 8, CourtName = Domain.Enum.CourtName.Court8, CourtStatus = Domain.Enum.CourtStatus.Available, Price = 40 },
//        new Court { CourtID = 9, CourtName = Domain.Enum.CourtName.Court9, CourtStatus = Domain.Enum.CourtStatus.Available, Price = 40 },
//        new Court { CourtID = 10, CourtName = Domain.Enum.CourtName.Court10, CourtStatus = Domain.Enum.CourtStatus.Available, Price = 40 }
//    );
//                context.SaveChanges();
//            }

//            if (!context.CourtBookings.Any())
//            {
//                context.CourtBookings.AddRange(
//        new CourtBooking { BookingId = 1, CourtId = 1 },
//        new CourtBooking { BookingId = 2, CourtId = 2 },
//        new CourtBooking { BookingId = 3, CourtId = 3 },
//        new CourtBooking { BookingId = 4, CourtId = 4 },
//        new CourtBooking { BookingId = 5, CourtId = 5 },
//        new CourtBooking { BookingId = 6, CourtId = 6 },
//        new CourtBooking { BookingId = 7, CourtId = 7 },
//        new CourtBooking { BookingId = 8, CourtId = 8 },
//        new CourtBooking { BookingId = 9, CourtId = 9 },
//        new CourtBooking { BookingId = 10, CourtId = 10 },
//        new CourtBooking { BookingId = 11, CourtId = 1 },
//        new CourtBooking { BookingId = 12, CourtId = 2 },
//        new CourtBooking { BookingId = 13, CourtId = 3 },
//        new CourtBooking { BookingId = 14, CourtId = 4 },
//        new CourtBooking { BookingId = 15, CourtId = 5 },
//        new CourtBooking { BookingId = 16, CourtId = 6 }
//    );
//                context.SaveChanges();
//            }
//            context.SaveChanges();
//        }
//    }
//}
