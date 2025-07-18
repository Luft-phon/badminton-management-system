using BadmintonCourtManagement.Application.DTO.Response.BookingResponseDTO;
using BadmintonCourtManagement.Application.DTO.Response.CourtResponseDTO;

namespace BadmintonCourtManagement.Domain.Interface
{
    public interface IBookingRepo
    {
        Task<IEnumerable<BookingDetailResponseDTO>> GetBookingDetails(string email);
        Task<IEnumerable<BookingDetailResponseDTO>> GetBookingHistory(string email);
    }
}
