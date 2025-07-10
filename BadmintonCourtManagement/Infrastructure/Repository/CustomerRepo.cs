using BadmintonCourtManagement.Application.DTO.Response.CustomerResponseDTO;
using BadmintonCourtManagement.Domain.Entity;
using BadmintonCourtManagement.Domain.Interface;
using BadmintonCourtManagement.Infrastructure.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BadmintonCourtManagement.Infrastructure.Repository
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly string _connectionString;
        private readonly ApplicationDbContext _context;

        public CustomerRepo(IConfiguration configuration, ApplicationDbContext context)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _context = context;
        }

        // Đang dùng ADO.NET => dài dòng
        //public async Task<IEnumerable<GetCustomerResponseDTO>> GetAllCustomers()
        //{
        //    var result = new List<GetCustomerResponseDTO>();

        //    using (SqlConnection con = new SqlConnection(_connectionString))
        //    {
        //        await con.OpenAsync();
        //        string sqlQuery = @"
        //        SELECT 
        //            u.FirstName + ' ' + u.LastName AS FullName,
        //            u.Phone,
        //            COUNT(b.BookingID) AS [TotalBooking],
        //            CASE 
        //                WHEN COUNT(CASE WHEN p.Status = 'Uncomplete' THEN 1 END) > 0 THEN 'Uncomplete'
        //                ELSE MAX(p.Status)
        //            END AS Status
        //        FROM [User] u
        //        LEFT JOIN Bookings b ON u.UserID = b.UserID
        //        LEFT JOIN Payments p ON b.BookingID = p.BookingID
        //        LEFT JOIN CourtBooking cb ON cb.BookingId = b.BookingID
        //        LEFT JOIN Courts c ON c.CourtID = cb.CourtId
        //        GROUP BY u.FirstName + ' ' + u.LastName, u.Phone";

        //        using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
        //        using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
        //        {
        //            while (await dr.ReadAsync())
        //            {
        //                result.Add(new GetCustomerResponseDTO
        //                {
        //                    FullName = dr["FullName"].ToString(),
        //                    Phone = dr["Phone"].ToString(),
        //                    TotalBooking = Convert.ToInt32(dr["TotalBooking"]),
        //                    Status = dr["Status"].ToString()
        //                });
        //            }
        //        }
        //    }

        //    return result;
        //}

        // use Dapper
        public async Task<IEnumerable<GetCustomerResponseDTO>> GetAllCustomers()
        {
            using var con = new SqlConnection(_connectionString);
            string sqlQuery = @"SELECT 
    u.UserID,u.FirstName + ' ' + u.LastName AS FullName,
    u.Phone, 
    COUNT(b.BookingID) AS [TotalBooking],
    CASE 
        WHEN COUNT(CASE WHEN p.Status = 'Uncomplete' THEN 1 END) > 0 THEN 'Uncomplete'
        ELSE MAX(p.Status)
    END AS Status, MAX(CAST(b.EndTime AS DATE)) as LastBooked, MAX(c.CourtName) as LastCourt
FROM [User] u
LEFT JOIN Bookings b ON u.UserID = b.UserID
LEFT JOIN Payments p ON b.BookingID = p.BookingID
LEFT JOIN CourtBookings cb ON cb.BookingId = b.BookingID
LEFT JOIN Courts c ON c.CourtID = cb.CourtId
WHERE u.[Role] = 'Member'
GROUP BY u.FirstName + ' ' + u.LastName, u.Phone, u.UserID";
            var result = await con.QueryAsync<GetCustomerResponseDTO>(sqlQuery);
            return result;
        }

        public async Task<GetCustomerByIdDTO> GetCustomerById(int id)
        {
            using var con = new SqlConnection(_connectionString);
            string sqlQuery = @"Select u.FirstName, u.LastName,  CONVERT(VARCHAR(10), u.Dob, 101) as Dob, a.Email, u.Phone, COUNT(b.BookingID) as [TotalBooking], p.Point as [Exp]
        FROM [User] u
        LEFT JOIN Bookings b ON u.UserID = b.UserID
        LEFT JOIN Points p ON u.UserID = p.UserID
		LEFT JOIN Account a ON a.UserID = u.UserID
        WHERE u.UserID = @UserId
        GROUP BY u.FirstName, u.LastName, u.Dob, a.Email, u.Phone, p.Point
		";

            var result = await con.QueryFirstOrDefaultAsync<GetCustomerByIdDTO>(sqlQuery, new { UserId = id });
            return result;
        }

        public async Task<IEnumerable<BookingHistoryResponseDTO>> GetCustomerBookingHistory(int id)
        {
            using var con = new SqlConnection(_connectionString);
            string sqlQuery = @"Select CAST(b.BookingDate AS DATE) as BookedDate, b.StartTime, b.EndTime, c.CourtName
FROM [User] u
JOIN Bookings b ON u.UserID = b.UserID
JOIN CourtBookings cb ON cb.BookingId = b.BookingID
JOIN Courts c ON c.CourtID = cb.CourtId
WHERE u.UserID = @UserId
GROUP BY b.BookingDate, b.StartTime, b.EndTime, c.CourtName";

            var result = await con.QueryAsync<BookingHistoryResponseDTO>(sqlQuery, new { UserId = id });
            return result;
        }
    }
}
