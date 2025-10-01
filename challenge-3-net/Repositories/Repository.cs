using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using challenge_3_net.Data;
using challenge_3_net.Repositories.Interfaces;

namespace challenge_3_net.Repositories
{
    /// <summary>
    /// Implementação base do repositório usando Entity Framework
    /// </summary>
    /// <typeparam name="T">Tipo da entidade</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<T?> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<bool> RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public virtual async Task<bool> RemoveByIdAsync(long id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
                return false;

            return await RemoveAsync(entity);
        }

        public virtual async Task<bool> ExistsAsync(long id)
        {
            return await _dbSet.FindAsync(id) != null;
        }

        public virtual async Task<long> CountAsync()
        {
            return await _dbSet.LongCountAsync();
        }

        public virtual async Task<long> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.LongCountAsync(predicate);
        }
    }
}
