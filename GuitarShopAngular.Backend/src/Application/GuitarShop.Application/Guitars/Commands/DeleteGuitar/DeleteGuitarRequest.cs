using MediatR;

namespace GuitarShop.Application.Guitars.Commands.DeleteGuitar
{
    public class DeleteGuitarRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
