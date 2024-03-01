using Application.Dto;
using Domain.Entity;
using MediatR;

namespace Application.Categories.Queries
{
    public class GetAllCategories:IRequest<List<GetCategoriesDto>>
    {
    }
}
