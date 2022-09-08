using GuitarShop.Application.Categories.Dto;
using MediatR;

namespace GuitarShop.Application.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdRequest : IRequest<CategoryDto>
    {
        public int Id { get; set; }
    }
}
