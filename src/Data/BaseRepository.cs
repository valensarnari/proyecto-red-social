using Microsoft.EntityFrameworkCore;
using Models.Abstractions;
using System.Threading;

namespace Data
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext _context;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null) return false;
            _context.Set<T>().Remove(entity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            var existingEntity = await _context.Set<T>().FindAsync(entity.Id);
            if (existingEntity == null) return null;
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            return existingEntity;
        }
    }
}
