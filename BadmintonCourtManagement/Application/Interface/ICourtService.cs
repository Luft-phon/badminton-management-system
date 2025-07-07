using BadmintonCourtManagement.Application.DTO.Request;
using BadmintonCourtManagement.Application.DTO.Response.CourtResponseDTO;

namespace BadmintonCourtManagement.Application.Interface
{
    public interface ICourtService
    {
        Task<IEnumerable<GetCourtResponseDTO>> GetCourts();
        Task<UpdateCourtStatusRequestDTO> UpdateCourt(UpdateCourtStatusRequestDTO dto);
    }
}
