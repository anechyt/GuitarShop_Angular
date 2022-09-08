using AutoMapper;
using GuitarShop.Application.Categories.Dto;
using GuitarShop.Domain.Entities;
using GuitarShop.Persistence;
using GuitarShop.Shared.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GuitarShop.Application.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdRequest, CategoryDto>
    {
        private readonly GuitarShopContext _context;
        private readonly IMapper _mapper;

        public GetCategoryByIdHandler(GuitarShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.AsNoTracking()
                   .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (category is null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }

            return _mapper.Map<CategoryDto>(category);
        }
    }
}
