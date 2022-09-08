using AutoMapper;
using GuitarShop.Application.Guitars.Dto;
using GuitarShop.Domain.Entities;
using GuitarShop.Persistence;
using GuitarShop.Shared.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GuitarShop.Application.Guitars.Queries.GetGuitarById
{
    public class GetGuitarByIdHandler : IRequestHandler<GetGuitarByIdRequest, GuitarDto>
    {
        private readonly GuitarShopContext _context;
        private readonly IMapper _mapper;

        public GetGuitarByIdHandler(GuitarShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GuitarDto> Handle(GetGuitarByIdRequest request, CancellationToken cancellationToken)
        {
            var guitar = await _context.Guitar.AsNoTracking()
                   .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (guitar is null)
            {
                throw new NotFoundException(nameof(Guitar), request.Id);
            }

            return _mapper.Map<GuitarDto>(guitar);
        }
    }
}
