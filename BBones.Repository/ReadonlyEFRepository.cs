using Microsoft.EntityFrameworkCore;
using BBones.Repository.Interfaces;

namespace BBones.Repository
{
    public class ReadonlyEFRepository<T> : IReadonlyRepository<T> where T : class
    {
        protected readonly DbContext _context;

        public ReadonlyEFRepository(DbContext context)
        {
            _context = context;
        }

        public List<T> Get(Func<T, bool>? predicate = null)
        {
            var dbSet = _context.Set<T>();
            if(predicate != null)
                return dbSet.Where(predicate).ToList();
            else
                return dbSet.ToList();
        }

        public T? FirstOrDefault(Func<T, bool> predicate)
            => _context.Set<T>().FirstOrDefault(predicate);

        public T? GetById(object id)
            => _context.Set<T>().Find(id);
    }
}