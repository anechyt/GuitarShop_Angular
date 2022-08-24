using GuitarShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuitarShop.Persistence
{
    public class GuitarShopContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Guitar> Guitar { get; set; }

        public GuitarShopContext(DbContextOptions<GuitarShopContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guitar>(entity =>
            {
                entity.HasOne(d => d.Category)
                .WithMany(p => p.Guitars)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Guitars_CategoryId");

            });

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
