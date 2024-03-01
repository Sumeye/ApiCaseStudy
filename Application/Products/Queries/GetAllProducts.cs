using Application.Dto;
using MediatR;

namespace Application.Products.Queries
{
    public class GetAllProducts : IRequest<List<GetProductsDto>>
    {
    }
}
