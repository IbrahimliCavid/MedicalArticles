using Core.Entities.Abstract;
using System.Linq.Expressions;

namespace Core.DataAccess.Abstract
{
    public interface IBaseRepository<T> where T : BaseEntity, new()
    {
        void Add(T  entity);
        void Update (T entity);
        void Delete (T entity);
        List<T> GetAll (Expression<Func<T, bool>> filter = null);
        T GetById (int id);
    }
}
