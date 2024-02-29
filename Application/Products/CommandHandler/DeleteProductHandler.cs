using Application.Products.Command;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Products.CommandHandler
{
    public class DeleteProductHandler : IRequestHandler<DeleteProduct, Unit>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteProduct request, CancellationToken cancellationToken)
        {
            Product deletedEntity = await _productRepository.GetByIdAsync(request.Id);
            _productRepository.Remove(deletedEntity);

            return Unit.Value;
        }
    }
}

