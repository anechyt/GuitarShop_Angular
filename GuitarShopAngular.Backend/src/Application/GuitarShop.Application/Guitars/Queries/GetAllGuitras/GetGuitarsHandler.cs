using AutoMapper;
using GuitarShop.Application.Guitars.Dto;
using GuitarShop.Persistence;
using GuitarShop.Shared.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GuitarShop.Application.Guitars.Queries.GetAllGuitras
{
    public class GetGuitarsHandler : IRequestHandler<GetGuitars, GuitarsList>
    {
        private readonly GuitarShopContext _context;
        private readonly IMapper _mapper;

        public GetGuitarsHandler(GuitarShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GuitarsList> Handle(GetGuitars request, CancellationToken cancellationToken)
        {
            var guitars = await _context.Guitar.AsNoTracking()
                    .Select(guitar => _mapper.Map<GuitarDto>(guitar))
                    .ToListAsync(cancellationToken);

            if (guitars is null)
            {
                throw new NotFoundException("Guitars is empty!");
            }

            return new GuitarsList { Guitars = guitars };
        }
    }
}
