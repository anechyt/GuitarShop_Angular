using GuitarShop.Application.Guitars.Commands.CreateGuitar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GuitarShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuitarController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GuitarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGuitar([FromBody] CreateGuitarRequest createGuitarRequest)
        {
            var result = await _mediator.Send(createGuitarRequest);
            return Ok(result);
        }
    }
}
