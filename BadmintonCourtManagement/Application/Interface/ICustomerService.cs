using BadmintonCourtManagement.Application.DTO.Request.UserRequest;
using BadmintonCourtManagement.Application.DTO.Response.CustomerResponseDTO;
using BadmintonCourtManagement.Application.DTO.Response.UserResponseDTO;
using BadmintonCourtManagement.Domain.Entity;

namespace BadmintonCourtManagement.Application.Interface
{
    public interface ICustomerService
    {
        Task<IEnumerable<GetCustomerResponseDTO>> GetAllCustomers(int pageNumber, int pageSize);
        Task<GetCustomerByIdDTO> GetCustomerById(int id);
        Task<UserRegistrationRequestDTO> RegisterCustomer(UserRegistrationRequestDTO dto);
        Task<UpdateCustomerRequestDTO> UpdateCustomerById(UpdateCustomerRequestDTO dto);

    }
}
