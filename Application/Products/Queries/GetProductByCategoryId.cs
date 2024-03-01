using Application.Dto;
using MediatR;

namespace Application.Products.Queries
{
    public class GetProductByCategoryId : IRequest<List<GetProductsByCategoryIdDto>>
    {
        public int CategoryId { get; set; }
    }
}
