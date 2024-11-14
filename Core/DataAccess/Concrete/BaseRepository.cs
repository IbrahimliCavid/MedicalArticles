using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.Concrete
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : BaseEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;

                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter )
        {
            using (TContext context = new TContext())
            {
                if(filter == null)
                    return context.Set<TEntity >().ToList();
                else
                    return context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity GetById(int id)
        {
            using(TContext context = new())
            {
                return context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
            }
        }
    }
}
