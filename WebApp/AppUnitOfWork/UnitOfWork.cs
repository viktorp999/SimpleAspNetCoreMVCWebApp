using WebApp.ApplicationDbContext;
using WebApp.AppRepository;
using WebApp.Models;

namespace WebApp.AppUnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        public IRepository<Car> CarRepository { get; private set; }
        public IRepository<Owner> OwnerRepository { get; private set; }

        public UnitOfWork(Context context)
        {
            _context = context;
            CarRepository = new Repository<Car>(_context);
            OwnerRepository = new Repository<Owner>(_context);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
