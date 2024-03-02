using Application.Categories.Command;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Categories.CommandHandlers
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategory,Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        public DeleteCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(DeleteCategory request,CancellationToken cancellationToken)
        {
              Category deletedEntity = await _categoryRepository.GetByIdAsync(request.Id);
             _categoryRepository.Remove(deletedEntity);

            return Unit.Value;
        }
    }
}
