using GuitarShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuitarShop.Persistence.Extensions
{
    public static class GuitarShopContextExtension
    {
        public static async Task MigrateDatabase(this GuitarShopContext _context)
        {
            try
            {
                if (_context.Database.IsSqlServer())
                {
                    await _context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task SeedDatabase(this GuitarShopContext _context)
        {
            try
            {
                await TrySeedDatabase(_context);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task TrySeedDatabase(this GuitarShopContext _context)
        {
            if (!_context.Category.Any())
            {
                var categories = new List<Category>()
                {
                    new Category()
                    {
                        Name = "TestCategory"
                    }
                };

                await _context.Category.AddRangeAsync(categories);
                await _context.SaveChangesAsync();
            }

            if (!_context.Guitar.Any())
            {
                var guitars = new List<Guitar>()
                {
                    new Guitar()
                    {
                        Name = "FirstGuitar",
                        Size = 1,
                        NumberOfStrings = 6,
                        Colour = "FirstColour",
                        Price = 1000,
                        PhotoUrl = "FirstPhotoUrl",
                        CategoryId = 1
                    },
                    new Guitar()
                    {
                        Name = "SecondGuitar",
                        Size = 1,
                        NumberOfStrings = 6,
                        Colour = "SecondColour",
                        Price = 1000,
                        PhotoUrl = "SecondPhotoUrl",
                        CategoryId = 1
                    }
                };

                await _context.Guitar.AddRangeAsync(guitars);
                await _context.SaveChangesAsync();
            }
        }

    }
}
