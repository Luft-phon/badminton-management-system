namespace BadmintonCourtManagement.Application.DTO.Request.UserRequest
{
    public class TokenRefreshRequestDTO
    {
        public string email { get; set; }
        public string RefreshToken { get; set; }
    }
}
