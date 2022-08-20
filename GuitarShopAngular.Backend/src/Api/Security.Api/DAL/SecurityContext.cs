using Microsoft.EntityFrameworkCore;
using Security.Api.Entity;

namespace Security.Api.DAL
{
    public class SecurityContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public SecurityContext(DbContextOptions<SecurityContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
