using MediatR;

namespace GuitarShop.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
