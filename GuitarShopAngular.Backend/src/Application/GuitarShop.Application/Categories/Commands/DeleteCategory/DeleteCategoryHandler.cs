using GuitarShop.Domain.Entities;
using GuitarShop.Persistence;
using GuitarShop.Shared.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GuitarShop.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryRequest, int>
    {
        private readonly GuitarShopContext _context;

        public DeleteCategoryHandler(GuitarShopContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (category is null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync(cancellationToken);

            return category.Id;
        }
    }
}
