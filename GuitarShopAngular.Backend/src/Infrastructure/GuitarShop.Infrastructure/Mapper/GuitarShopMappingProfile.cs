using AutoMapper;
using GuitarShop.Application.Categories.Commands.CreateCategory;
using GuitarShop.Application.Categories.Dto;
using GuitarShop.Application.Guitars.Commands.CreateGuitar;
using GuitarShop.Application.Guitars.Dto;
using GuitarShop.Domain.Entities;

namespace GuitarShop.Infrastructure.Mapper
{
    public class GuitarShopMappingProfile : Profile
    {
        public GuitarShopMappingProfile()
        {
            CreateMap<Guitar, GuitarDto>().ReverseMap();
            CreateMap<CreateGuitarRequest, Guitar>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CreateCategoryRequest, Category>().ReverseMap();
        }
    }
}
