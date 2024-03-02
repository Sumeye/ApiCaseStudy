using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected  readonly DbContext _context;
        private readonly DbSet<TEntity> _dbset;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbset = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbset.Add(entity);
            _context.SaveChanges();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbset.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _dbset.FindAsync(id);
            if (entity != null)
            {

                _context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public void Remove(TEntity entity)
        {
            _dbset.Remove(entity);
            _context.SaveChanges();
        }

        public TEntity Update(TEntity entity)
        {
             _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;

        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbset.Where(predicate);
        }
    }
}
