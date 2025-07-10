using BadmintonCourtManagement.Application.DTO.Response.CustomerResponseDTO;
using BadmintonCourtManagement.Domain.Entity;

namespace BadmintonCourtManagement.Domain.Interface
{
    public interface ICustomerRepo
    {
        Task<IEnumerable<GetCustomerResponseDTO>> GetAllCustomers();
        Task<GetCustomerByIdDTO> GetCustomerById(int id);
        Task<IEnumerable<BookingHistoryResponseDTO>> GetCustomerBookingHistory(int id);
    }
}
