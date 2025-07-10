using BadmintonCourtManagement.Application.DTO.Request.BookingRequest;
using BadmintonCourtManagement.Application.DTO.Response;
using BadmintonCourtManagement.Application.DTO.Response.BookingResponseDTO;
using BadmintonCourtManagement.Application.Interface;
using BadmintonCourtManagement.Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonCourtManagement.Controllers.CustomerController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly IBookingService _service;
        public BookingController(IBookingService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpPost]
        [Route("createBooking")]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingRequestDTO dto)
        {
            try
            {
                var booking = await _service.CreateBooking(dto);
                return Ok(ApiResponse<CreateBookingResponseDTO>.Success(booking));
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorResponse.InternalError(500, ex.Message));
            }
        }
    }
}
