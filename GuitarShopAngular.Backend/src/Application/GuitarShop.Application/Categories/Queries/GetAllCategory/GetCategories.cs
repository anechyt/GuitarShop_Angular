using GuitarShop.Application.Categories.Dto;
using MediatR;

namespace GuitarShop.Application.Categories.Queries.GetAllCategory
{
    public class GetCategories : IRequest<CategoriesList>
    {
    }
}
