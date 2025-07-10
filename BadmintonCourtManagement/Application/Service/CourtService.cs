using BadmintonCourtManagement.Application.DTO.Request.CourtRequest;
using BadmintonCourtManagement.Application.DTO.Response.CourtResponseDTO;
using BadmintonCourtManagement.Application.Interface;
using BadmintonCourtManagement.Application.UseCase;

namespace BadmintonCourtManagement.Application.Service
{
    public class CourtService : ICourtService
    {
        private readonly CourtUseCase _courtUseCase;

        public CourtService(CourtUseCase courtUseCase)
        {
            _courtUseCase = courtUseCase;
        }
        public async Task<IEnumerable<GetCourtResponseDTO>> GetCourts()
        {
            return await _courtUseCase.GetCourts();
        }

        public async Task<UpdateCourtStatusRequestDTO> UpdateCourt(UpdateCourtStatusRequestDTO dto)
        {
            return await _courtUseCase.UpdateCourt(dto);
        }
    }
}
