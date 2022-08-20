using Security.Api.Dto;
using Security.Api.Entity;

namespace Security.Api.Repositories.Contracts
{
    public interface ISecurityRepository
    {
        Task<AuthenticateResult> Authenticate(User user);
        Task Registration(User user);
    }
}
