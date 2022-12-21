using Microsoft.EntityFrameworkCore;
using WebApp.EntityConfig;
using WebApp.Models;

namespace WebApp.ApplicationDbContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public virtual DbSet<TestObj> Test { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarConfig());
            modelBuilder.ApplyConfiguration(new OwnerConfig());
        }
    }
}
