using BadmintonCourtManagement.Application.DTO.Request.BookingRequest;
using BadmintonCourtManagement.Application.DTO.Response.BookingResponseDTO;
using BadmintonCourtManagement.Application.Interface;
using BadmintonCourtManagement.Application.UseCase;
using BadmintonCourtManagement.Infrastructure.Data;

namespace BadmintonCourtManagement.Application.Service
{
    public class BookingService : IBookingService
    {
        private readonly BookingUseCase _useCase;
        public BookingService(BookingUseCase useCase)
        {
            _useCase = useCase;
        }

        public Task<string> CancelBooking(int bookingID)
        {
            return _useCase.CancelBooking(bookingID);
        }

        public Task<CreateBookingResponseDTO> CreateBooking(CreateBookingRequestDTO dto)
        {
            return _useCase.CreateBooking(dto);
        }

        public Task<IEnumerable<BookingDetailResponseDTO>> GetBookingDetail(BookingDetailRequestDTO dto)
        {
            return _useCase.GetBookingDetail(dto);
        }

        public Task<IEnumerable<BookingDetailResponseDTO>> GetBookingsHistory(BookingDetailRequestDTO dto)
        {
            return _useCase.GetBookingHistory(dto);
        }
    }
}
