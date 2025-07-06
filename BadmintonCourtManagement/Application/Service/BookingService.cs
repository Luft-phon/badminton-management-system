using BadmintonCourtManagement.Application.DTO.Request;
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

        public Task<CreateBookingResponseDTO> CreateBooking(CreateBookingRequestDTO dto)
        {
            return _useCase.CreateBooking(dto);
        }
    }
}
