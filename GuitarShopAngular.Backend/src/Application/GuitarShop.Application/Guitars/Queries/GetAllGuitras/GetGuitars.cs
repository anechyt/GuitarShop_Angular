using GuitarShop.Application.Guitars.Dto;
using MediatR;

namespace GuitarShop.Application.Guitars.Queries.GetAllGuitras
{
    public class GetGuitars : IRequest<GuitarsList>
    {
    }
}
