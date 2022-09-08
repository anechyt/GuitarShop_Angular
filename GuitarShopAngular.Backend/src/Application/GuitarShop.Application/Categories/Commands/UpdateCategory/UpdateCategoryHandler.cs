using AutoMapper;
using GuitarShop.Application.Categories.Dto;
using GuitarShop.Domain.Entities;
using GuitarShop.Persistence;
using GuitarShop.Shared.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GuitarShop.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryRequest, CategoryDto>
    {
        private readonly GuitarShopContext _context;
        private readonly IMapper _mapper;

        public UpdateCategoryHandler(GuitarShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (category is null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }

            category.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CategoryDto>(category);
        }
    }
}
