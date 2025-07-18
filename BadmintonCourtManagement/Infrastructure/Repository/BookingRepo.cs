using BadmintonCourtManagement.Application.DTO.Response.BookingResponseDTO;
using BadmintonCourtManagement.Application.DTO.Response.CourtResponseDTO;
using BadmintonCourtManagement.Domain.Interface;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BadmintonCourtManagement.Infrastructure.Repository
{
    public class BookingRepo : IBookingRepo
    {
        private readonly string _connectionString;
        public BookingRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<IEnumerable<BookingDetailResponseDTO>> GetBookingDetails(string email)
        {
            using var connection = new SqlConnection(_connectionString);
            string sqlQuery = @"SELECT u.FirstName + ' ' + u.LastName as [Name], u.Phone, b.BookingID, b.Status as BookingStatus, co.CourtName,
CAST(b.StartTime as TIME) as [StartTime], CAST(b.EndTime as TIME) as [EndTime], CONVERT(VARCHAR(10), b.BookingDate, 101) as [CreateDate], CONVERT(VARCHAR(10), b.StartTime, 101) as BookingDate,
b.TotalHourBooked, p.Amount as [PaymentAmount], p.Status as [PaymentStatus]
FROM Bookings b
JOIN CourtBookings cb ON b.BookingID =cb.BookingId
JOIN Courts co ON co.CourtId = cb.CourtId
JOIN [User] u ON b.UserID = u.UserID
JOIN Account c ON u.UserID = c.UserID
JOIN Payments p ON p.BookingID = b.BookingID
WHERE c.Email = @Email AND b.StartTime > GETDATE()
";
            var result = await connection.QueryAsync<BookingDetailResponseDTO>(sqlQuery, new {Email = email});
            return result;
        }

        public async Task<IEnumerable<BookingDetailResponseDTO>> GetBookingHistory(string email)
        {
            using var connection = new SqlConnection(_connectionString);
            string sqlQuery = @"SELECT u.FirstName + ' ' + u.LastName as [Name], u.Phone, b.BookingID, b.Status as BookingStatus, co.CourtName,
CAST(b.StartTime as TIME) as [StartTime], CAST(b.EndTime as TIME) as [EndTime], CONVERT(VARCHAR(10), b.BookingDate, 101) as [CreateDate], CONVERT(VARCHAR(10), b.StartTime, 101) as BookingDate,
b.TotalHourBooked, p.Amount as [PaymentAmount], p.Status as [PaymentStatus]
FROM Bookings b
JOIN CourtBookings cb ON b.BookingID =cb.BookingId
JOIN Courts co ON co.CourtId = cb.CourtId
JOIN [User] u ON b.UserID = u.UserID
JOIN Account c ON u.UserID = c.UserID
JOIN Payments p ON p.BookingID = b.BookingID
WHERE c.Email = @Email
";
            var result = await connection.QueryAsync<BookingDetailResponseDTO>(sqlQuery, new { Email = email });
            return result;
        }
    }
}
