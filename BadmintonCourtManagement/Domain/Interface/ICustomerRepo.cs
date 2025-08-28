using BadmintonCourtManagement.Application.DTO.Request.UserRequest;
using BadmintonCourtManagement.Application.DTO.Response.CustomerResponseDTO;
using BadmintonCourtManagement.Application.DTO.Response.UserResponseDTO;
using BadmintonCourtManagement.Domain.Entity;

namespace BadmintonCourtManagement.Domain.Interface
{
    public interface ICustomerRepo
    {
        Task<IEnumerable<GetCustomerResponseDTO>> GetAllCustomers();
        Task<GetCustomerByIdDTO> GetCustomerById(int id);
        Task<IEnumerable<BookingHistoryResponseDTO>> GetCustomerBookingHistory(int id);
        Task<GetUserDetailResponseDTO> GetUserDetail(string email);
    }
}
