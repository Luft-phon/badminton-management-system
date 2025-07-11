namespace BadmintonCourtManagement.Application.DTO.Request.SendMailRequest
{
    public class VerificationCodeRequestDTO
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
}
