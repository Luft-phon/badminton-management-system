using BadmintonCourtManagement.Application.DTO.Request.SendMailRequest;
using BadmintonCourtManagement.Application.DTO.Request.UserRequest;
using BadmintonCourtManagement.Application.DTO.Response.CustomerResponseDTO;
using BadmintonCourtManagement.Application.DTO.Response.UserResponseDTO;
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
        public Task<IEnumerable<GetCustomerResponseDTO>> GetAllCustomers()
        {
            return useCase.GetAllCustomers();
        }

        public Task<GetCustomerByIdDTO> GetCustomerById(int id)
        {
            return useCase.GetCustomerById(id);
        }

        public Task<GetUserDetailResponseDTO> GetUserDetail(string email)
        {
            return useCase.GetUserDetail(email);
        }

        public Task<string> RegisterCustomer(VerificationCodeRequestDTO dto)
        {
            return useCase.RegisterCustomer(dto);
        }

        public Task<UpdateCustomerRequestDTO> UpdateCustomerById(UpdateCustomerRequestDTO dto)
        {
            return useCase.UpdateCustomerById(dto);
        }
    }
}
