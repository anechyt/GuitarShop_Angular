using GuitarShop.Application.Guitars.Dto;
using MediatR;

namespace GuitarShop.Application.Guitars.Commands.CreateGuitar
{
    public class CreateGuitarRequest : IRequest<GuitarDto>
    {
        public string Name { get; set; } = null!;
        public double Size { get; set; }
        public int NumberOfStrings { get; set; }
        public string Colour { get; set; } = null!;
        public decimal Price { get; set; }
        public string PhotoUrl { get; set; } = null!;
        public int CategoryId { get; set; }
    }
}
