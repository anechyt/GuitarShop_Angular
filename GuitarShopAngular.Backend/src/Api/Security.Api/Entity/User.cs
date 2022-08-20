using Security.Api.Const;

namespace Security.Api.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = Constants.UserRole;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
