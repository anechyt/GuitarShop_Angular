namespace GuitarShop.Application.Guitars.Dto
{
    public class GuitarDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Size { get; set; }
        public int NumberOfStrings { get; set; }
        public string Colour { get; set; }
        public decimal Price { get; set; }
        public string PhotoUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
