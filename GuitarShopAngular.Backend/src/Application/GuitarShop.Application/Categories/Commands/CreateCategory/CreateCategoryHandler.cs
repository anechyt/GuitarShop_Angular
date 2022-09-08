using AutoMapper;
using GuitarShop.Application.Categories.Dto;
using GuitarShop.Domain.Entities;
using GuitarShop.Persistence;
using MediatR;

namespace GuitarShop.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryRequest, CategoryDto>
    {
        private readonly GuitarShopContext _context;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(GuitarShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);

            _context.Categories.Add(category);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CategoryDto>(category);
        }
    }
}
