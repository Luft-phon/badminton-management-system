using BadmintonCourtManagement.Application.Utils;
using BadmintonCourtManagement.Domain.Entity;
using BadmintonCourtManagement.Domain.Interface;
using BadmintonCourtManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BadmintonCourtManagement.Infrastructure.Repository
{
    public class TokenRepo : ITokenRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly TokenValidation _tokenValidation;
        private readonly IUnitOfWork _unitOfWork;

        public TokenRepo(ApplicationDbContext context, TokenValidation tokenValidation, IUnitOfWork unitOfWork)
        {
            _context = context;
            _tokenValidation = tokenValidation;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> SaveRefreshToken(User user)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                // Check if the user already has a refresh token
                var existingToken = await _context.Tokens.FirstOrDefaultAsync(t => t.UserID == user.UserID);
                if (existingToken != null)
                {
                    // If a token exists, update it
                    existingToken.RefreshToken = _tokenValidation.CreateRefreshToken();
                    existingToken.ExpiresAt = DateTime.UtcNow.AddDays(7);
                    existingToken.RevokedAt = null;
                    _context.Update(existingToken);
                    await _context.SaveChangesAsync();
                    return existingToken.RefreshToken;
                }
                // If no token exists, create a new one
                var refreshToken = _tokenValidation.CreateRefreshToken();
                var token = new Token();
                token.RefreshToken = refreshToken;
                token.ExpiresAt = DateTime.UtcNow.AddDays(7);
                token.UserID = user.UserID;
                token.RevokedAt = null;
                _context.Add(token);
                await _context.SaveChangesAsync();
                return refreshToken;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw new Exception("Error saving refresh token", ex);
            }
            finally
            {
                await _unitOfWork.CommitAsync();

            }
        }
    }
}
