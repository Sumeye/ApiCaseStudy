using Application.Dto;
using MediatR;

namespace Application.Products.Command
{
    public class CreateProduct:IRequest<CreatedProductDto>
    {
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }
    }
}
