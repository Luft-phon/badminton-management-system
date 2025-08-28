using BadmintonCourtManagement.Domain.Enum;

namespace BadmintonCourtManagement.Application.DTO.Response.UserResponseDTO
{
    public class TokenResponseDTO
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Role { get; set; }
    }
}
