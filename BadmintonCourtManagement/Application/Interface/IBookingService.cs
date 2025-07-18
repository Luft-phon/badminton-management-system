using BadmintonCourtManagement.Application.DTO.Request.BookingRequest;
using BadmintonCourtManagement.Application.DTO.Response.BookingResponseDTO;

namespace BadmintonCourtManagement.Application.Interface
{
    public interface IBookingService
    {
        Task<CreateBookingResponseDTO> CreateBooking(CreateBookingRequestDTO request);
        Task<IEnumerable<BookingDetailResponseDTO>> GetBookingDetail(BookingDetailRequestDTO dto);
    }
}
