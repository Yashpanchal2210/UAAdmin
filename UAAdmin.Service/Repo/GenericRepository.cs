using System.Linq.Expressions;

namespace UAAdmin.Service.Repo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly UrbanAutoMasterContext _dbContext;

        public GenericRepository(UrbanAutoMasterContext context)
        {
            _dbContext = context;
        }
        public int Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return _dbContext.SaveChanges();
        }
        public int Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges();
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }
        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }
        public int Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChanges();
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }
    }
}
