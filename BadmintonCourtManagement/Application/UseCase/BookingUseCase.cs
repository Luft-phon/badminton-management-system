using BadmintonCourtManagement.Application.DTO.Request;
using BadmintonCourtManagement.Application.DTO.Response.BookingResponseDTO;
using BadmintonCourtManagement.Application.Utils;
using BadmintonCourtManagement.Domain.Entity;
using BadmintonCourtManagement.Domain.Enum;
using BadmintonCourtManagement.Infrastructure.Data;
using BadmintonCourtManagement.Infrastructure.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BadmintonCourtManagement.Application.UseCase
{
    public class BookingUseCase
    {
        private readonly ApplicationDbContext _context;
        private readonly UnitOfWork _unitOfWork;
        private readonly BookingValidation _bookingValidation;

        public BookingUseCase(ApplicationDbContext context, UnitOfWork unitOfWork, BookingValidation bookingValidation)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _bookingValidation = bookingValidation;
        }

        public async Task<CreateBookingResponseDTO> CreateBooking(CreateBookingRequestDTO dto)
        {

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var user = await _context.User.FindAsync(dto.UserID);
                if (user == null)
                {
                    return new CreateBookingResponseDTO
                    {
                        Status = 404,
                        Messege = "Can find userID"
                    };
                }
                var courtEnums = dto.CourtNames
                    .Select(name => Enum.Parse<CourtName>(name))
                    .ToList();

                var courtIds = await _context.Courts
                    .Where(c => courtEnums.Contains(c.CourtName))
                    .Select(c => c.CourtID)
                    .ToListAsync();

                // Check if there is any time conflict
                bool isConflict = await _bookingValidation.IsConflict(dto);
                bool isValidDuration = await _bookingValidation.IsValidDuration(dto);
                bool isValid = await _bookingValidation.isValidTime(dto);
                if (isConflict || !isValidDuration || !isValid)
                {
                    return new CreateBookingResponseDTO
                    {
                        Status = 400,
                        Messege = "Please select an available time"
                    };
                }
                else
                {
                    var start = TimeOnly.Parse(dto.StartTime);
                    var end = TimeOnly.Parse(dto.EndTime);

                    var startTime = dto.Date.ToDateTime(start);
                    var endTime = dto.Date.ToDateTime(end);

                    var booking = new Booking
                    {
                        StartTime = dto.Date.ToDateTime(start),
                        EndTime = dto.Date.ToDateTime(end),
                        TotalHourBooked = (end - start).TotalHours,
                        ReportID = null,
                        UserID = dto.UserID,
                        Status = Domain.Enum.BookingStatus.Booked,
                        BookingDate = DateTime.Now,
                        courtBookings = courtIds.Select(id => new CourtBooking
                        {
                            CourtId = id,
                            BookingId = 0 
                        }).ToList()
                    };

                    _context.Add(booking);
                    await _context.SaveChangesAsync();

                    // Update CourtBooking with the generated BookingId
                    foreach (var courtBooking in booking.courtBookings)
                    {
                        courtBooking.BookingId = booking.BookingID;
                    }

                    var payment = new Payment
                    {
                        BookingID = booking.BookingID,
                        Amount = 0,
                        PaidAt = null,
                        Status = PaymentStatus.Uncomplete
                    };

                    _context.Payments.Add(payment);
                    await _context.SaveChangesAsync();
                    await _unitOfWork.CommitAsync();
                    return new CreateBookingResponseDTO
                    {
                        Status = 200,
                        Messege = "Your booking confirmation",
                        UserID = dto.UserID,
                        Date = dto.Date,
                        CourtNames = dto.CourtNames,
                        EndTime = dto.EndTime,
                        StartTime = dto.StartTime
                    };
                }
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw new Exception("Error: ", ex);
            }
        }
        
    }
}
