using BadmintonCourtManagement.Application.DTO.Request.UserRequest;
using BadmintonCourtManagement.Application.DTO.Response.UserResponseDTO;

namespace BadmintonCourtManagement.Application.Interface
{
    public interface IUserService
    {
        Task<TokenResponseDTO> Login(LoginRequestDTO dto);
        Task<TokenResponseDTO> RefreshToken(TokenRefreshRequestDTO dto);
    }
}
