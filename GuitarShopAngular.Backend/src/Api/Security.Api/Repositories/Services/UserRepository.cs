using Microsoft.EntityFrameworkCore;
using Security.Api.DAL;
using Security.Api.Entity;
using Security.Api.Repositories.Contracts;

namespace Security.Api.Repositories.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly SecurityContext _securityContext;
        public UserRepository(SecurityContext securityContext)
        {
            _securityContext = securityContext;
        }
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _securityContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _securityContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<User> GetByLoginAsync(string login)
        {
            return await _securityContext.Users.FirstOrDefaultAsync(x => x.Login == login);
        }
    }
}
