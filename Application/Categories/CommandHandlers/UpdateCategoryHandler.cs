using Application.Categories.Command;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Categories.CommandHandlers
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategory, int>
    {
        private readonly ICategoryRepository _categoryRepository;
        public UpdateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<int> Handle(UpdateCategory request, CancellationToken cancellationToken)
        {

            var updatedCategoryEntity = new Category()
            {
                CategoryId = request.Id,
                CategoryName = request.CategoryName,

            };
            Category updatedEntity = _categoryRepository.Update(updatedCategoryEntity);
            return updatedEntity.CategoryId;
        }
    }
}
