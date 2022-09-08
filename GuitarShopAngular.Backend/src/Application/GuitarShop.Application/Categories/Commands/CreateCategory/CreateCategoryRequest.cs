using GuitarShop.Application.Categories.Dto;
using MediatR;

namespace GuitarShop.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryRequest : IRequest<CategoryDto>
    {
        public string Name { get; set; } = null!;
    }
}
