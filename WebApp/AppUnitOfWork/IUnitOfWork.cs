using WebApp.AppRepository;
using WebApp.Models;

namespace WebApp.AppUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Car> CarRepository { get; }
        IRepository<Owner> OwnerRepository { get; }
        int Save();
    }
}
