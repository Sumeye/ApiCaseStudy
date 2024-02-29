using Application.Dto;
using Application.Products.Command;
using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Products.CommandHandler
{
    public class CreateProductHandler : IRequestHandler<CreateProduct, CreatedProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public CreateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreatedProductDto> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            Product mappedProduct = _mapper.Map<Product>(request);
            Product CreatedProduct = await _productRepository.AddAsync(mappedProduct);
            CreatedProductDto createdProductDto = _mapper.Map<CreatedProductDto>(CreatedProduct);
            return createdProductDto;

        }
    }
}
