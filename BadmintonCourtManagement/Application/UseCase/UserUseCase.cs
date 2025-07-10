using Azure.Core;
using BadmintonCourtManagement.Application.DTO.Request.UserRequest;
using BadmintonCourtManagement.Application.DTO.Response.UserResponseDTO;
using BadmintonCourtManagement.Application.Utils;
using BadmintonCourtManagement.Domain.Entity;
using BadmintonCourtManagement.Domain.Interface;
using BadmintonCourtManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BadmintonCourtManagement.Application.UseCase
{
    public class UserUseCase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICustomerRepo _customerRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly TokenValidation tokenValidation;
        private readonly ITokenRepo _tokenRepo;

        public UserUseCase(ApplicationDbContext context, ICustomerRepo customerRepo, IUnitOfWork unitOfWork, TokenValidation token, ITokenRepo tokenRepo)
        {
            _context = context;
            _customerRepo = customerRepo;
            _unitOfWork = unitOfWork;
            tokenValidation = token;
            _tokenRepo = tokenRepo;
        }
        public async Task<TokenResponseDTO> Login(LoginRequestDTO dto)
        {
            var account = await _context.Account.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (account == null)
            {
                return null;
            }
            var user = await _context.User.FirstOrDefaultAsync(u => u.UserID == account.UserID);
            var hashPassword = new PasswordHasher<Account>().VerifyHashedPassword(account, account.Password, dto.Password);
            if (hashPassword == PasswordVerificationResult.Failed)
            {
                return null;
            }
            var response = new TokenResponseDTO
            {
                AccessToken = tokenValidation.CreateToken(account, user),
                RefreshToken = await _tokenRepo.SaveRefreshToken(user)
            };
            return response;
        }

        public async Task<TokenResponseDTO> RefreshToken(TokenRefreshRequestDTO dto)
        {
            // Validate the existing refresh token
            var account = await _context.Account.FirstOrDefaultAsync(u => u.UserID == dto.UserID);
            var token = await _context.Tokens.FirstOrDefaultAsync(t => t.UserID == dto.UserID && t.RefreshToken == dto.RefreshToken && t.ExpiresAt >= DateTime.UtcNow);
            if (account == null || token is null) {
                return null;
            }
            var user = await _context.User.FirstOrDefaultAsync(u => u.UserID == account.UserID);

            var response = new TokenResponseDTO
            {
                AccessToken = tokenValidation.CreateToken(account, user),
                RefreshToken = await _tokenRepo.SaveRefreshToken(user)
            };
            return response;
        }
    }
}
