using Application.Categories.Command;
using Application.Dto;
using Application.Products.Command;
using AutoMapper;
using Domain.Entity;

namespace Application.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CreatedCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategory>().ReverseMap();
            CreateMap<Product, CreatedProductDto>().ReverseMap();
            CreateMap<Product, CreateProduct>().ReverseMap();
        }
    }
}
