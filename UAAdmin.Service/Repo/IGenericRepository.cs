using System.Linq.Expressions;

namespace UAAdmin.Service.Repo
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        int Add(T entity);
        int Update(T entity);
        void AddRange(IEnumerable<T> entities);
        int Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
