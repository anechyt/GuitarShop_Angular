using GuitarShop.Application.Categories.Dto;
using MediatR;

namespace GuitarShop.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryRequest : IRequest<CategoryDto>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
