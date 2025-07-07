using BadmintonCourtManagement.Application.DTO.Request;
using BadmintonCourtManagement.Application.DTO.Response.CourtResponseDTO;
using BadmintonCourtManagement.Domain.Enum;
using BadmintonCourtManagement.Domain.Interface;
using BadmintonCourtManagement.Infrastructure.Data;

namespace BadmintonCourtManagement.Application.UseCase
{
    public class CourtUseCase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICourtRepo _courtRepo;
        private readonly IUnitOfWork _unitOfWork;
        public CourtUseCase(ICourtRepo courtRepo, ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _courtRepo = courtRepo;
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<GetCourtResponseDTO>> GetCourts()
        {
            return await _courtRepo.GetCourts();
        }

        public async Task<UpdateCourtStatusRequestDTO> UpdateCourt(UpdateCourtStatusRequestDTO dto)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var court = await _context.Courts.FindAsync(dto.CourtID);
                if (court == null)
                {
                    throw new Exception("Court not found");
                }

                // Convert the string CourtStatus to the CourtStatus enum
                if (!Enum.TryParse(dto.CourtStatus, out CourtStatus courtStatus))
                {
                    throw new Exception("Invalid CourtStatus value");
                }

                court.CourtStatus = courtStatus;
                _context.Courts.Update(court);
                await _context.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
                return dto;
            } catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw new Exception("An error occurred while updating the court status", ex);
            }
            
        }
    }
}
