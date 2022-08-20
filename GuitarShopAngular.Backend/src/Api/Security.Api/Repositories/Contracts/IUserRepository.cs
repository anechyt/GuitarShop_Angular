using Security.Api.Entity;

namespace Security.Api.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByLoginAsync(string login);
        Task<User> GetByIdAsync(int id);
    }
}
