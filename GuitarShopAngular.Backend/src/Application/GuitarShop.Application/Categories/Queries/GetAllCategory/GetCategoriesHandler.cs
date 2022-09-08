using AutoMapper;
using GuitarShop.Application.Categories.Dto;
using GuitarShop.Persistence;
using GuitarShop.Shared.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GuitarShop.Application.Categories.Queries.GetAllCategory
{
    public class GetCategoriesHandler : IRequestHandler<GetCategories, CategoriesList>
    {
        private readonly GuitarShopContext _context;
        private readonly IMapper _mapper;

        public GetCategoriesHandler(GuitarShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CategoriesList> Handle(GetCategories request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories.AsNoTracking()
                    .Select(category => _mapper.Map<CategoryDto>(category))
                    .ToListAsync(cancellationToken);

            if (categories is null)
            {
                throw new NotFoundException("Categories is empty!");
            }

            return new CategoriesList { Categories = categories };
        }
    }
}
