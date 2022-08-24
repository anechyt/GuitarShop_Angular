using GuitarShop.Domain.ValueObjects;

namespace GuitarShop.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Guitars = new HashSet<Guitar>();
        }
        public int Id { get; set; }
        public Name Name { get; set; } = null!;

        public ICollection<Guitar> Guitars { get; set; }
    }
}
