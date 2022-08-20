using Microsoft.IdentityModel.Tokens;
using Security.Api.Security.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Security.Api.Security.TokenValidators
{
    public class RefreshTokenValidator
    {
        private readonly JwtOptions _jwtOptions;

        public RefreshTokenValidator(JwtOptions jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }

        public bool Validate(string refreshToken)
        {
            TokenValidationParameters validationParameters = new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.RefreshTokenSecret)),
                ValidIssuer = _jwtOptions.Issuer,
                ValidAudience = _jwtOptions.Audience,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ClockSkew = TimeSpan.Zero
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                tokenHandler.ValidateToken(refreshToken, validationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
