using BadmintonCourtManagement.Application.DTO.Response.CourtResponseDTO;

namespace BadmintonCourtManagement.Domain.Interface
{
    public interface ICourtRepo
    {
        Task<IEnumerable<GetCourtResponseDTO>> GetCourts();
    }
}
