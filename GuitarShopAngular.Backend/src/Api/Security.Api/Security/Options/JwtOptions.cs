namespace Security.Api.Security.Options
{
    public class JwtOptions
    {
        public string AccessTokenSecret { get; set; } = string.Empty;
        public float AccessTokenExpirationMinutes { get; set; }
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string RefreshTokenSecret { get; set; } = string.Empty;
        public float RefreshTokenExpirationMinutes { get; set; }
    }
}
