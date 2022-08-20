using Security.Api.DAL;
using Security.Api.Dto;
using Security.Api.Entity;
using Security.Api.Repositories.Contracts;
using Security.Api.Security.TokenGenerators;

namespace Security.Api.Repositories.Services
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly SecurityContext _securityContext;
        private readonly IUserRepository _userRepository;
        private readonly AccessTokenGenerator _accessTokenGenerator;
        private readonly RefreshTokenGenerator _refreshTokenGenerator;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IPasswordHasher _passwordHasher;

        public SecurityRepository(
            SecurityContext securityContext,
            IUserRepository userRepository,
            AccessTokenGenerator accessTokenGenerator,
            RefreshTokenGenerator refreshTokenGenerator,
            IRefreshTokenRepository refreshTokenRepository,
            IPasswordHasher passwordHasher)
        {
            _securityContext = securityContext;
            _userRepository = userRepository;
            _accessTokenGenerator = accessTokenGenerator;
            _refreshTokenGenerator = refreshTokenGenerator;
            _refreshTokenRepository = refreshTokenRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<AuthenticateResult> Authenticate(User user)
        {
            AccessToken accessToken = _accessTokenGenerator.GenerateToken(user);
            string refreshToken = _refreshTokenGenerator.GenerateToken();
            var refreshTokenDto = new RefreshToken
            {
                Token = refreshToken,
                UserId = user.UserId
            };
            await _refreshTokenRepository.CreateAsync(refreshTokenDto);
            return new AuthenticateResult
            {
                AccessToken = accessToken.Value,
                AccessTokenExpirationTime = accessToken.ExpirationTime,
                RefreshToken = refreshToken
            };
        }

        public async Task Registration(User user)
        {
            var emailAlredyExist = await _userRepository.GetByEmailAsync(user.Email);
            if (emailAlredyExist != null)
                throw new System.Exception("Error Email");

            var loginAlreadyExist = await _userRepository.GetByLoginAsync(user.Login);
            if (loginAlreadyExist != null)
                throw new System.Exception("Error Login");

            var passwordHash = _passwordHasher.HashPassword(user.Password);

            var newUser = new User
            {
                Email = user.Email,
                Login = user.Login,
                Password = passwordHash,
                CreatedAt = DateTime.Now
            };

            await _securityContext.Users.AddAsync(newUser);
            await _securityContext.SaveChangesAsync();
        }
    }
}
