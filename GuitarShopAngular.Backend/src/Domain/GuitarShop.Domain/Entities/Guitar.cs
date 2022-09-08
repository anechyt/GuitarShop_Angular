using GuitarShop.Domain.ValueObjects;

namespace GuitarShop.Domain.Entities
{
    public class Guitar
    {
        public int Id { get; set; }
        public Name Name { get; set; }
        public Size Size { get; set; }
        public NumberOfStrings NumberOfStrings { get; set; }
        public Colour Colour { get; set; }
        public Price Price { get; set; }
        public PhotoUrl PhotoUrl { get; set; }
        public int CategoryId { get; set; }

        public Category Categories { get; set; }
    }
}
