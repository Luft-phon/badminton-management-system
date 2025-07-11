using BadmintonCourtManagement.Application.DTO.Request.SendMailRequest;
using BadmintonCourtManagement.Application.DTO.Request.UserRequest;

namespace BadmintonCourtManagement.Application.Interface
{
    public interface IEmailService
    {
        Task<string> SendContactUsEmailAsync(ContactUsRequestDTO request);
        Task<string> SendVerificationEmail(UserRegistrationRequestDTO dto);
    }
}
