using Microsoft.EntityFrameworkCore;
using BBones.Repository.Interfaces;

namespace BBones.Repository
{
    public class EFRepository<T> : ReadonlyEFRepository<T>, IRepository<T> where T : class
    {
        public EFRepository(DbContext context) : base(context)
        {
        }

        public Task Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return _context.SaveChangesAsync();
        }
        

        public Task Create(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            return _context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return _context.SaveChangesAsync();
        }

        public Task Update(IEnumerable<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
            return _context.SaveChangesAsync();
        }

        public Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChangesAsync();
        }

        public Task Delete(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            return _context.SaveChangesAsync();
        }
    }
}