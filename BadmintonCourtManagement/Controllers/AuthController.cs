using BadmintonCourtManagement.Application.DTO.Request.SendMailRequest;
using BadmintonCourtManagement.Application.DTO.Request.UserRequest;
using BadmintonCourtManagement.Application.DTO.Response;
using BadmintonCourtManagement.Application.DTO.Response.UserResponseDTO;
using BadmintonCourtManagement.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonCourtManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly ICustomerService _customerService;
        private readonly IUserService _userService;
        public AuthController(ICustomerService customerService, IUserService userService)
        {
            _customerService = customerService;
            _userService = userService;
        }

        [HttpPost("register-user")]
        public async Task<IActionResult> Register(VerificationCodeRequestDTO dto)
        {
            try
            {
                var user = await _customerService.RegisterCustomer(dto);
                if (user is null)
                {
                    return BadRequest(ErrorResponse.InternalError(StatusCodes.Status400BadRequest, "User registration failed"));
                }
                return Ok(ApiResponse<string>.Success(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorResponse.InternalError(400, ex.Message));
            }
        }

        [HttpPost("login-user")]
        public async Task<IActionResult> Login(LoginRequestDTO dto)
        {
            try
            {
                var user = await _userService.Login(dto);
                if (user is null)
                {
                    return BadRequest(ErrorResponse.NotFound());
                }
                return Ok(ApiResponse<TokenResponseDTO>.Success(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorResponse.InternalError(400, ex.Message));
            }
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(TokenRefreshRequestDTO dto)
        {
            try
            {
                var refreshToken = await _userService.RefreshToken(dto);
                if (refreshToken is null || refreshToken.AccessToken is null || refreshToken.RefreshToken is null)
                {
                    return Unauthorized("Invalid token");
                }
                return Ok(refreshToken);
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorResponse.InternalError(400, ex.Message));
            }
        }

        [Authorize(Roles = "Member")]
        [HttpGet("check-token")]
        public IActionResult CheckToken()
        {
            return Ok("Token is valid");
        }

    }
}
