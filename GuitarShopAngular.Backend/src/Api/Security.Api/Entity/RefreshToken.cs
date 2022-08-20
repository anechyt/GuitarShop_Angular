namespace Security.Api.Entity
{
    public class RefreshToken
    {
        public int RefreshTokenId { get; set; }
        public string Token { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
