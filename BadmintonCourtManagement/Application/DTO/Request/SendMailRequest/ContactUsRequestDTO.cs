namespace BadmintonCourtManagement.Application.DTO.Request.SendMailRequest
{
    public class ContactUsRequestDTO
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
