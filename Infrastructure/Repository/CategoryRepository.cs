using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }

    }
}

