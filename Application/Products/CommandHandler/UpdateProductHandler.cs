using Application.Products.Command;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Products.CommandHandler
{
    public class UpdateProductHandler : IRequestHandler<UpdateProduct, int>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(UpdateProduct request, CancellationToken cancellationToken)
        {
            var updatedProductEntity = new Product()
            {
                CategoryId = request.CategoryId,
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
                Id = request.Id,
                UserId=request.UserId,
            };
            Product updatedEntity = _productRepository.Update(updatedProductEntity);
            return updatedEntity.Id;
        }
    }
}
