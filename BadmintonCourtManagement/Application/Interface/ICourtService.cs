﻿using BadmintonCourtManagement.Application.DTO.Request.CourtRequest;
using BadmintonCourtManagement.Application.DTO.Response.CourtResponseDTO;

namespace BadmintonCourtManagement.Application.Interface
{
    public interface ICourtService
    {
        Task<IEnumerable<GetCourtResponseDTO>> GetCourts();
        Task<UpdateCourtStatusRequestDTO> UpdateCourt(UpdateCourtStatusRequestDTO dto);
    }
}
