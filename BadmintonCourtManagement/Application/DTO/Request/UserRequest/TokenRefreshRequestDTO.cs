namespace BadmintonCourtManagement.Application.DTO.Request.UserRequest
{
    public class TokenRefreshRequestDTO
    {
        public int UserID { get; set; }
        public string RefreshToken { get; set; }
    }
}
