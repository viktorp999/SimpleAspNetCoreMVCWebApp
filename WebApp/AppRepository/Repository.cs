using Microsoft.EntityFrameworkCore;

namespace WebApp.AppRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext context;
        protected readonly DbSet<T> dbset;

        public Repository(DbContext context)
        {
            this.context = context;
            dbset = this.context.Set<T>();
        }

        public T Get(int id)
        {
            return dbset.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public void Delete(int id)
        {
            T entity = dbset.Find(id);
            dbset.Remove(entity);
        }

        public void Update(T entity)
        {
            dbset.Update(entity);
        }
    }
}
