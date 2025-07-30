using BadmintonCourtManagement.Application.DTO.Request.BookingRequest;
using BadmintonCourtManagement.Application.DTO.Response.BookingResponseDTO;
using BadmintonCourtManagement.Application.Utils;
using BadmintonCourtManagement.Domain.Entity;
using BadmintonCourtManagement.Domain.Enum;
using BadmintonCourtManagement.Domain.Interface;
using BadmintonCourtManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BadmintonCourtManagement.Application.UseCase
{
    public class BookingUseCase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly BookingValidation _bookingValidation;
        private readonly IBookingRepo _bookingRepo;

        public BookingUseCase(ApplicationDbContext context, IUnitOfWork unitOfWork, BookingValidation bookingValidation, IBookingRepo bookingRepo)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _bookingValidation = bookingValidation;
            _bookingRepo = bookingRepo;
        }

        public async Task<CreateBookingResponseDTO> CreateBooking(CreateBookingRequestDTO dto)
        {

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var user = await _context.User.FindAsync(dto.UserID);
                if (user == null)
                {
                    throw new Exception("Invalid user ID");
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
                    throw new Exception("Invalid booking time");
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
                        Amount = ((end - start).TotalHours) * 40.00,
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
                throw;
            }
        }

        public async Task<IEnumerable<BookingDetailResponseDTO>> GetBookingDetail(BookingDetailRequestDTO dto)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var result = new List<BookingDetailResponseDTO>();
                var bookingDetail = await _bookingRepo.GetBookingDetails(dto.email);
                if (bookingDetail is null)
                {
                    return null;
                }
                result.AddRange(bookingDetail);
                await _unitOfWork.CommitAsync();
                return result.ToList();
            }
            catch (Exception ex) { 
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<string> CancelBooking(int bookingID)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                string result;
                var bookings = await _context.Bookings
                    .Where(b => b.StartTime > DateTime.UtcNow)
                    .FirstOrDefaultAsync(b => b.BookingID == bookingID);
                    
                if (bookings == null) {
                    throw new Exception("Booking is not found");
                }
                bookings.Status = BookingStatus.Canceled;
                _context.Update(bookings);
                await _context.SaveChangesAsync();
                 result = bookings.Status.ToString();
                await _unitOfWork.CommitAsync();
                return result;
            }
            catch (Exception ex) { 
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<IEnumerable<BookingDetailResponseDTO>> GetBookingHistory(BookingDetailRequestDTO dto)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var result = new List<BookingDetailResponseDTO>();
                var bookingDetail = await _bookingRepo.GetBookingHistory(dto.email);
                if (bookingDetail is null)
                {
                    return null;
                }
                result.AddRange(bookingDetail);
                await _unitOfWork.CommitAsync();
                return result.ToList();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}
