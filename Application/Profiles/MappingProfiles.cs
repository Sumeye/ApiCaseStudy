using Application.Categories.Command;
using Application.Categories.Queries;
using Application.Dto;
using Application.Products.Command;
using Application.Products.Queries;
using Application.User.Command;
using AutoMapper;
using Domain.Entity;

namespace Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CreatedCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategory>().ReverseMap();
            CreateMap<Category, GetAllCategories>().ReverseMap();
            CreateMap<Category, GetCategoriesDto>().ReverseMap();


            CreateMap<Product, CreatedProductDto>().ReverseMap();
            CreateMap<Product, CreateProduct>().ReverseMap();
            CreateMap<Product, GetProductByCategoryId>().ReverseMap();
            CreateMap<Product, GetProductsDto>().ReverseMap();
            CreateMap<Product, GetAllProducts>().ReverseMap();
            CreateMap<Product, GetProductsByCategoryIdDto>().ReverseMap();

            CreateMap<Users, CreateUser>().ReverseMap();




        }
    }
}
