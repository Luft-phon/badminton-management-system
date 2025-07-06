using BadmintonCourtManagement.Application.DTO.Request;
using BadmintonCourtManagement.Application.DTO.Response.BookingResponseDTO;

namespace BadmintonCourtManagement.Application.Interface
{
    public interface IBookingService
    {
        Task<CreateBookingResponseDTO> CreateBooking(CreateBookingRequestDTO request); 
    }
}
