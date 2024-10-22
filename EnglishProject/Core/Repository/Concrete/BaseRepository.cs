using EnglishProject.Core.Repository.Abstract;
using EnglishProject.Data;
using System.Linq.Expressions;

namespace EnglishProject.Core.Repository.Concrete
{
    public class BaseRepository<TEntity>
        where TEntity : class,new()
    {
        private readonly WordDbContext _context;
        public BaseRepository(WordDbContext wordDbContext)
        {
            _context = wordDbContext;
        }
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
             _context.SaveChanges();
            
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().FirstOrDefault(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? _context.Set<TEntity>().ToList() :
                _context.Set<TEntity>().Where(filter).ToList();
            
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
