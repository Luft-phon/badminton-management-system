using BadmintonCourtManagement.Application.DTO.Request.SendMailRequest;
using BadmintonCourtManagement.Application.DTO.Request.UserRequest;
using BadmintonCourtManagement.Application.DTO.Response;
using BadmintonCourtManagement.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonCourtManagement.Controllers.CustomerController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("contact-us")]
        public async Task<IActionResult> ContactUs([FromBody] ContactUsRequestDTO request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }
            try
            {
                var email = await _emailService.SendContactUsEmailAsync(request);
                return Ok(ApiResponse<string>.Success(email));
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorResponse.InternalError(400, "Invalid email"));
            }
        }

        [HttpPost("verification-email")]
        public async Task<IActionResult> RegisterVerificationEmail(UserRegistrationRequestDTO dto)
        {
            try
            {
                var verifiedEmail = await  _emailService.SendVerificationEmail(dto);
                return Ok(ApiResponse<string>.Success(verifiedEmail));
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorResponse.InternalError(500, ex.Message));
            }
        }
    }
}
