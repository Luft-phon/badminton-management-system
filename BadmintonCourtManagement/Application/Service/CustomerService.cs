using BadmintonCourtManagement.Application.DTO.Request;
using BadmintonCourtManagement.Application.DTO.Response.CustomerResponseDTO;
using BadmintonCourtManagement.Application.Interface;
using BadmintonCourtManagement.Application.UseCase;
using BadmintonCourtManagement.Domain.Entity;

namespace BadmintonCourtManagement.Application.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerUseCase useCase;
        public CustomerService(CustomerUseCase useCase)
        {
            this.useCase = useCase;
        }
        public Task<IEnumerable<GetCustomerResponseDTO>> GetAllCustomers(int pageNumber, int pageSize)
        {
            return useCase.GetAllCustomers(pageNumber, pageSize);
        }

        public Task<GetCustomerByIdDTO> GetCustomerById(int id)
        {
            return useCase.GetCustomerById(id);
        }

        public Task<UpdateCustomerRequestDTO> UpdateCustomerById(UpdateCustomerRequestDTO dto)
        {
            return useCase.UpdateCustomerById(dto);
        }
    }
}
