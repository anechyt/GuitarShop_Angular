using Microsoft.IdentityModel.Tokens;
using Security.Api.Entity;
using Security.Api.Security.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Security.Api.Security.TokenGenerators
{
    public class JwtTokenGenerator
    {
        public string GenerateToken(string secretKey, string issuer, string audience, DateTime utcExpirationTime,
            IEnumerable<Claim> claims = null)
        {
            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                DateTime.UtcNow,
                utcExpirationTime,
                credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
    public class AccessTokenGenerator
    {
        private readonly JwtOptions _jwtOptions;
        private readonly JwtTokenGenerator _tokenGenerator;

        public AccessTokenGenerator(JwtOptions jwtOptions, JwtTokenGenerator tokenGenerator)
        {
            _jwtOptions = jwtOptions;
            _tokenGenerator = tokenGenerator;
        }

        public AccessToken GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("UserId", user.UserId.ToString()),
                new Claim("Role", user.Role.ToString())
            };

            DateTime expirationTime = DateTime.UtcNow.AddMinutes(_jwtOptions.AccessTokenExpirationMinutes);

            string value = _tokenGenerator.GenerateToken(
                _jwtOptions.AccessTokenSecret,
                _jwtOptions.Issuer,
                _jwtOptions.Audience,
                expirationTime,
                claims);

            return new AccessToken()
            {
                Value = value,
                ExpirationTime = expirationTime
            };
        }
    }

    public class RefreshTokenGenerator
    {
        private readonly JwtOptions _jwtOptions;
        private readonly JwtTokenGenerator _tokenGenerator;

        public RefreshTokenGenerator(JwtOptions jwtOptions, JwtTokenGenerator tokenGenerator)
        {
            _jwtOptions = jwtOptions;
            _tokenGenerator = tokenGenerator;
        }

        public string GenerateToken()
        {
            DateTime expirationTime = DateTime.UtcNow.AddMinutes(_jwtOptions.RefreshTokenExpirationMinutes);

            return _tokenGenerator.GenerateToken(
                _jwtOptions.RefreshTokenSecret,
                _jwtOptions.Issuer,
                _jwtOptions.Audience,
                expirationTime);
        }
    }
}
