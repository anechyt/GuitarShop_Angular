using Microsoft.EntityFrameworkCore;
using Security.Api.DAL;
using Security.Api.Entity;
using Security.Api.Repositories.Contracts;

namespace Security.Api.Repositories.Services
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly SecurityContext _securityContext;
        public RefreshTokenRepository(SecurityContext securityContext)
        {
            _securityContext = securityContext;
        }
        public async Task CreateAsync(RefreshToken refreshToken)
        {
            await _securityContext.RefreshTokens.AddAsync(refreshToken);
            await _securityContext.SaveChangesAsync();
        }

        public async Task DeleteAllAsync(int userId)
        {
            IEnumerable<RefreshToken> refreshTokens = await _securityContext.RefreshTokens
                .Where(t => t.UserId == userId)
                .ToListAsync();

            _securityContext.RefreshTokens.RemoveRange(refreshTokens);
            await _securityContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _securityContext.RefreshTokens.FindAsync(id);
            _securityContext.RefreshTokens.Remove(result);
            await _securityContext.SaveChangesAsync();
        }

        public async Task<RefreshToken> GetByTokenAsync(string token)
        {
            return await _securityContext.RefreshTokens.FirstAsync(t => t.Token == token);
        }
    }
}
