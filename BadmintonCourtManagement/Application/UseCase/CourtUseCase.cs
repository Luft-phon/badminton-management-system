using BadmintonCourtManagement.Application.DTO.Request.CourtRequest;
using BadmintonCourtManagement.Application.DTO.Response.CourtResponseDTO;
using BadmintonCourtManagement.Application.DTO.Response.CustomerResponseDTO;
using BadmintonCourtManagement.Domain.Entity;
using BadmintonCourtManagement.Domain.Enum;
using BadmintonCourtManagement.Domain.Interface;
using BadmintonCourtManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BadmintonCourtManagement.Application.UseCase
{
    public class CourtUseCase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICourtRepo _courtRepo;
        private readonly IUnitOfWork _unitOfWork;
        public CourtUseCase(ICourtRepo courtRepo, ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _courtRepo = courtRepo;
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<GetCourtResponseDTO>> GetCourts()
        {
            var court = await _context.Courts
                .Include(cb => cb.courtBookings)             // left join table
                   .ThenInclude(c => c.Booking)         
                      .ToListAsync();
            var dtoList = court.Select(c => new GetCourtResponseDTO
            {
                CourtID = c.CourtID,
                CourtName = c.CourtName.ToString(),
                CourtStatus = c.CourtStatus.ToString(),
                Next_booking_date = c.courtBookings
                                    .Where(cb => cb.Booking.StartTime > DateTime.UtcNow)
                                    .OrderByDescending(cb => cb.Booking.StartTime)
                                    .Select(c => c.Booking.StartTime.ToString("MM/dd/yyyy"))
                                    .FirstOrDefault(),
                 Next_booking_hour = c.courtBookings
                                    .Where(cb => cb.Booking.StartTime > DateTime.UtcNow)
                                    .OrderByDescending(cb => cb.Booking.StartTime)
                                    .Select(c => c.Booking.StartTime.ToString("HH:mm"))
                                    .FirstOrDefault(),
                booking = c.courtBookings.Select(cb => new BookingHistoryResponseDTO { 
                    BookingID = cb.Booking.BookingID,
                    StartTime = cb.Booking.StartTime,
                    EndTime = cb.Booking.EndTime,
                    BookedDate = cb.Booking.BookingDate,
                    CourtName = cb.Court.CourtName.ToString(),
                    Status = cb.Booking.Status.ToString()
                }).ToList()
            }).ToList();
            return dtoList;
        }

        public async Task<UpdateCourtStatusRequestDTO> UpdateCourt(UpdateCourtStatusRequestDTO dto)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var court = await _context.Courts.FindAsync(dto.CourtID);
                if (court == null)
                {
                    throw new Exception("Court not found");
                }

                // Convert the string CourtStatus to the CourtStatus enum
                if (!Enum.TryParse(dto.CourtStatus, out CourtStatus courtStatus))
                {
                    throw new Exception("Invalid CourtStatus value");
                }

                court.CourtStatus = courtStatus;
                _context.Courts.Update(court);
                await _context.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
                return dto;
            } catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw new Exception("An error occurred while updating the court status", ex);
            }
            
        }
    }
}
