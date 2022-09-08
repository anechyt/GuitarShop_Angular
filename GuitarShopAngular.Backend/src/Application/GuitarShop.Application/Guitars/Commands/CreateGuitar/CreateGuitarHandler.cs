using AutoMapper;
using GuitarShop.Application.Guitars.Dto;
using GuitarShop.Domain.Entities;
using GuitarShop.Persistence;
using MediatR;

namespace GuitarShop.Application.Guitars.Commands.CreateGuitar
{
    public class CreateGuitarHandler : IRequestHandler<CreateGuitarRequest, GuitarDto>
    {
        private readonly GuitarShopContext _context;
        private readonly IMapper _mapper;

        public CreateGuitarHandler(GuitarShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GuitarDto> Handle(CreateGuitarRequest request, CancellationToken cancellationToken)
        {
            var guitar = _mapper.Map<Guitar>(request);

            _context.Guitar.Add(guitar);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<GuitarDto>(guitar);
        }
    }
}
