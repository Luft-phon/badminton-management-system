using BadmintonCourtManagement.Application.DTO.Request;
using BadmintonCourtManagement.Application.DTO.Response;
using BadmintonCourtManagement.Application.DTO.Response.BookingResponseDTO;
using BadmintonCourtManagement.Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonCourtManagement.Controllers.CustomerController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly BookingService _service;
        public BookingController(BookingService service)
        {
            _service = service;
        }

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
