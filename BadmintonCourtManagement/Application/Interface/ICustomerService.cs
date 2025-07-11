using BadmintonCourtManagement.Application.DTO.Request.SendMailRequest;
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
        Task<string> RegisterCustomer(VerificationCodeRequestDTO dto);
        Task<UpdateCustomerRequestDTO> UpdateCustomerById(UpdateCustomerRequestDTO dto);

    }
}
