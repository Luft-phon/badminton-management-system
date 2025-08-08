using BadmintonCourtManagement.Application.DTO.Request.UserRequest;
using BadmintonCourtManagement.Application.DTO.Response.UserResponseDTO;
using BadmintonCourtManagement.Application.Interface;
using BadmintonCourtManagement.Application.UseCase;

namespace BadmintonCourtManagement.Application.Service
{
    public class UserService : IUserService
    {
        private readonly UserUseCase _useCase;
        public UserService(UserUseCase useCase)
        {
            _useCase = useCase;
        }
        public Task<TokenResponseDTO> Login(LoginRequestDTO dto)
        {
            return _useCase.Login(dto);
        }

        public Task<TokenResponseDTO> RefreshToken(TokenRefreshRequestDTO dto)
        {
            return _useCase.RefreshToken(dto);
        }
        public Task<string> DeleteAccount(int userID)
        {
            return _useCase.DeleteAccount(userID);
        }
    }
}
