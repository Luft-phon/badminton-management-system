using BadmintonCourtManagement.Application.DTO.Request;
using BadmintonCourtManagement.Application.DTO.Response.CustomerResponseDTO;
using BadmintonCourtManagement.Domain.Entity;

namespace BadmintonCourtManagement.Application.Interface
{
    public interface ICustomerService
    {
        Task<IEnumerable<GetCustomerResponseDTO>> GetAllCustomers(int pageNumber, int pageSize);
        Task<GetCustomerByIdDTO> GetCustomerById(int id);
        Task<UpdateCustomerRequestDTO> UpdateCustomerById(UpdateCustomerRequestDTO dto);

    }
}
