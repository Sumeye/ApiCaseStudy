using Application.Dto;
using Application.Products.Queries;
using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.QueryHandler
{
    public class GetProductByCategoryIdHandler : IRequestHandler<GetProductByCategoryId, List<GetProductsByCategoryIdDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByCategoryIdHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<GetProductsByCategoryIdDto>> Handle(GetProductByCategoryId request, CancellationToken cancellationToken)
        {
            List<Product> products = _productRepository.Where(x => x.CategoryId == request.CategoryId).ToList();

            List<GetProductsByCategoryIdDto> getProductByCategoryIdDtos = _mapper.Map<List<GetProductsByCategoryIdDto>>(products);

            return getProductByCategoryIdDtos;
        }


    }
}
