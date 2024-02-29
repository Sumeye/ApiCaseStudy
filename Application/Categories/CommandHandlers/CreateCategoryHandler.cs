using Application.Categories.Command;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Categories.CommandHandlers
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategory, CreatedCategoryDto>
    {
        private readonly ICategoryRepository _categoriesRepository;
        private readonly IMapper _mapper;
        public CreateCategoryHandler(ICategoryRepository categoriesRepository, IMapper mapper)
        {
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
        }
        public async Task<CreatedCategoryDto> Handle(CreateCategory request, CancellationToken cancellationToken)
        {
            Category mappedCategories = _mapper.Map<Category>(request);
            Category CreatedCategories = await _categoriesRepository.AddAsync(mappedCategories);
            CreatedCategoryDto createdCategoriesDto = _mapper.Map<CreatedCategoryDto>(CreatedCategories);

            return createdCategoriesDto;
        }
    }
}
