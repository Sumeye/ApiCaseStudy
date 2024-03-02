using Application.Categories.Queries;
using Application.Dto;
using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Categories.QueryHandlers
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategories, List<GetCategoriesDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriesHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCategoriesDto>> Handle(GetAllCategories request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();
            var mappedCategories = _mapper.Map<List<GetCategoriesDto>>(categories);
            return mappedCategories;

        }
    }
}
