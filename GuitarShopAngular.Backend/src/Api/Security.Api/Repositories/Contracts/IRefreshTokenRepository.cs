using Security.Api.Entity;

namespace Security.Api.Repositories.Contracts
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetByTokenAsync(string token);

        Task CreateAsync(RefreshToken refreshToken);

        Task DeleteAsync(int id);

        Task DeleteAllAsync(int userId);
    }
}
