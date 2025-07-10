using BadmintonCourtManagement.Application.DTO.Request.CourtRequest;
using BadmintonCourtManagement.Application.DTO.Response;
using BadmintonCourtManagement.Application.DTO.Response.CourtResponseDTO;
using BadmintonCourtManagement.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonCourtManagement.Controllers.CourtController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourtController : ControllerBase
    {
        private readonly ICourtService courtService;
        public CourtController(ICourtService courtService)
        {
            this.courtService = courtService;
        }

        [Authorize(Roles = "Staff, Owner")]
        [HttpGet]
        [Route("getCourts")]
        public async Task<IActionResult> GetCourts()
        {
            try
            {
                var courts = await courtService.GetCourts();
                return Ok(ApiResponse<IEnumerable<GetCourtResponseDTO>>.Success(courts));
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorResponse.InternalError(500, ex.Message));
            }
        }

        [Authorize(Roles = "Staff, Owner")]
        [HttpPut]
        [Route("update-court")]
        public async Task<IActionResult> UpdateCourt(UpdateCourtStatusRequestDTO dto)
        {
            try
            {
                var updatedCourt = await courtService.UpdateCourt(dto);
                return Ok(ApiResponse<UpdateCourtStatusRequestDTO>.Success(updatedCourt));
            }
            catch (Exception ex)
            {
                return BadRequest(ErrorResponse.InternalError(500, ex.Message));
            }
        }
    }
}
