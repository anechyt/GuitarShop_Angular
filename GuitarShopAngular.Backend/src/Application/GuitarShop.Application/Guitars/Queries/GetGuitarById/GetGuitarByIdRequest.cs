using GuitarShop.Application.Guitars.Dto;
using MediatR;

namespace GuitarShop.Application.Guitars.Queries.GetGuitarById
{
    public class GetGuitarByIdRequest : IRequest<GuitarDto>
    {
        public int Id { get; set; }
    }
}
