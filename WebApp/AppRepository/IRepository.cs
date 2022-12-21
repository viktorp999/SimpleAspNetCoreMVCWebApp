
namespace WebApp.AppRepository
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
    }
}
