using BadmintonCourtManagement.Domain.Entity;

namespace BadmintonCourtManagement.Domain.Interface
{
    public interface ITokenRepo
    {
        Task<string> SaveRefreshToken(User user);
    }
}
