using FirstGenericRepository.DataAcces.Context;
using FirstGenericRepository.Domain.Repository;

namespace FirstGenericRepository.DataAcces.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly FirstGenericRepositoryDbContext _context;

        public GenericRepository(FirstGenericRepositoryDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T? GetByGuid(Guid id) => _context.Set<T>().Find(id);

        public T? GetById(int id) => _context.Set<T>().Find(id);

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }

}
