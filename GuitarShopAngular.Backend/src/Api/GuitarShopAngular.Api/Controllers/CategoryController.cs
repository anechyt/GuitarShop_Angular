using GuitarShop.Application.Categories.Commands.CreateCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GuitarShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGuitar([FromBody] CreateCategoryRequest createCategoryRequest)
        {
            var result = await _mediator.Send(createCategoryRequest);
            return Ok(result);
        }
    }
}
