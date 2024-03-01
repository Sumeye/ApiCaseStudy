using Application.Dto;
using Application.Products.Queries;
using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Products.QueryHandler
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProducts, List<GetProductsDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<GetProductsDto>> Handle(GetAllProducts request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();
            List<GetProductsDto> getProducts = _mapper.Map<List<GetProductsDto>>(products);
            return getProducts;
        }
    }
}
