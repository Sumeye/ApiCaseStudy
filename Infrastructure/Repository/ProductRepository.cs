using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context){  }

    }
}