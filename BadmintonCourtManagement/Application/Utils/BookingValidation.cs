using BadmintonCourtManagement.Application.DTO.Request.BookingRequest;
using BadmintonCourtManagement.Domain.Enum;
using BadmintonCourtManagement.Infrastructure.Data;
using BadmintonCourtManagement.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace BadmintonCourtManagement.Application.Utils
{
    public class BookingValidation
    {
        private readonly ApplicationDbContext _context;

        public BookingValidation(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<bool> IsValidDuration(CreateBookingRequestDTO dto)
        {
            var start = TimeOnly.Parse(dto.StartTime);
            var end = TimeOnly.Parse(dto.EndTime);

            var startTime = dto.Date.ToDateTime(start);
            var endTime = dto.Date.ToDateTime(end);

            var totalHour = (endTime - startTime).TotalMinutes;
            return Task.FromResult(totalHour >= 60);
        }
        public Task<bool> isValidTime(CreateBookingRequestDTO dto)
        {
            var start = TimeOnly.Parse(dto.StartTime);
            var end = TimeOnly.Parse(dto.EndTime);
            var startTime = dto.Date.ToDateTime(start);
            var endTime = dto.Date.ToDateTime(end);

            var currentTime = DateTime.Now;

            return Task.FromResult((startTime < endTime) && (startTime > currentTime));
        }
        public async Task<bool> IsConflict(CreateBookingRequestDTO dto)
        {
            var start = TimeOnly.Parse(dto.StartTime);
            var end = TimeOnly.Parse(dto.EndTime);

            var startTime = dto.Date.ToDateTime(start);
            var endTime = dto.Date.ToDateTime(end);

            var courtEnums = dto.CourtNames
  .Select(name => Enum.Parse<CourtName>(name))
  .ToList();

            var courtIds = await _context.Courts
                .Where(c => courtEnums.Contains(c.CourtName))
                .Select(c => c.CourtID)
                .ToListAsync();


            bool isConfict = await _context.CourtBookings
                .Where(c => courtIds.Contains(c.CourtId))
                .AnyAsync(cd => cd.Booking.StartTime < endTime 
                    && cd.Booking.EndTime > startTime 
                    && cd.Booking.Status == BookingStatus.Booked);
   
            if (isConfict)
            {
                return true;
            }
            return false;
        }
    }
}
