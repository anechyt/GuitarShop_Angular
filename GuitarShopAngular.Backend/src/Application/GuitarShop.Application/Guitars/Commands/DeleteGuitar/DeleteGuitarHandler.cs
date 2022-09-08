using GuitarShop.Domain.Entities;
using GuitarShop.Persistence;
using GuitarShop.Shared.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GuitarShop.Application.Guitars.Commands.DeleteGuitar
{
    public class DeleteGuitarHandler : IRequestHandler<DeleteGuitarRequest, int>
    {
        private readonly GuitarShopContext _context;

        public DeleteGuitarHandler(GuitarShopContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteGuitarRequest request, CancellationToken cancellationToken)
        {
            var guitar = await _context.Guitar.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (guitar is null)
            {
                throw new NotFoundException(nameof(Guitar), request.Id);
            }

            _context.Guitar.Remove(guitar);
            await _context.SaveChangesAsync(cancellationToken);

            return guitar.Id;
        }
    }
}
