using AutoMapper;
using GuitarShop.Application.Guitars.Dto;
using GuitarShop.Domain.Entities;
using GuitarShop.Persistence;
using GuitarShop.Shared.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GuitarShop.Application.Guitars.Commands.UpdateGuitar
{
    public class UpdateGuitarHandler : IRequestHandler<UpdateGuitarRequest, GuitarDto>
    {
        private readonly GuitarShopContext _context;
        private readonly IMapper _mapper;

        public UpdateGuitarHandler(GuitarShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GuitarDto> Handle(UpdateGuitarRequest request, CancellationToken cancellationToken)
        {
            var guitar = await _context.Guitar
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (guitar is null)
            {
                throw new NotFoundException(nameof(Guitar), request.Id);
            }

            guitar.Name = request.Name;
            guitar.Size = request.Size;
            guitar.NumberOfStrings = request.NumberOfStrings;
            guitar.Colour = request.Colour;
            guitar.Price = request.Price;
            guitar.PhotoUrl = request.PhotoUrl;
            guitar.CategoryId = request.CategoryId;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<GuitarDto>(guitar);
        }
    }
}
