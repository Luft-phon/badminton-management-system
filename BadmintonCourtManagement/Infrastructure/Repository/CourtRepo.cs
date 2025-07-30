using BadmintonCourtManagement.Application.DTO.Response.CourtResponseDTO;
using BadmintonCourtManagement.Domain.Interface;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BadmintonCourtManagement.Infrastructure.Repository
{
    public class CourtRepo : ICourtRepo
    {
        private readonly string _connectionString;

        public CourtRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<IEnumerable<GetCourtResponseDTO>> GetCourts()
        {
            using var connection = new SqlConnection(_connectionString);
            string sqlQuery = @"SELECT   c.CourtID,c.CourtName,  
CONVERT(VARCHAR(10), MAX(b.StartTime), 101) AS [Next_booking_date], 
CONVERT(VARCHAR(5), MAX(b.StartTime), 108) AS [Next_booking_hour] ,
c.CourtStatus, b.StartTime, b.EndTime
FROM Courts c
LEFT JOIN CourtBookings cb ON c.CourtID = cb.CourtId
LEFT JOIN Bookings b ON cb.BookingId = b.BookingID AND b.StartTime > GETDATE()
GROUP BY c.CourtName, c.CourtStatus, c.CourtID, b.StartTime, b.EndTime";
            var result = await connection.QueryAsync<GetCourtResponseDTO>(sqlQuery);
            return result;
        }
    }
}
