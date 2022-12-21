using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Moq;
using WebApp.AppRepository;
using WebApp.ApplicationDbContext;
using WebApp.Models;

namespace WebAppUnitTests
{
    [TestFixture]
    public class RepositoryTests
    {
        private Mock<Context> _context;
        private Mock<DbSet<TestObj>> _dbset;
        private Repository<TestObj> _obj;
        private DbContextOptions<Context> _options;

        [SetUp]
        public void SetUp()
        {
            _options = new DbContextOptionsBuilder<Context>().UseInMemoryDatabase(databaseName: "DB").Options;
            _context = new Mock<Context>(_options);
            _dbset = new Mock<DbSet<TestObj>>();
            _obj = new Repository<TestObj>(_context.Object);
        }

        [Test]
        public void Add_WhenCalled_AddRecord()
        {
            TestObj test = new TestObj
            {
                Id = 1,
            };

            _context.Setup(x => x.Test).Returns(_dbset.Object);

            _obj.Add(test);

            _dbset.Verify(x => x.Add(It.IsAny<TestObj>()), Times.Once);
        }

        [Test]
        public void GetAll_WhenCalled_ReturnAllRecords()
        {
            var test = new List<TestObj>
            {
                new TestObj
                {

                    Id = 1
                },

                new TestObj
                {
                    Id = 2
                }
            }.AsQueryable();

            _dbset.As<IQueryable<TestObj>>().Setup(x => x.Provider).Returns(test.AsQueryable().Provider);
            _dbset.As<IQueryable<TestObj>>().Setup(x => x.Expression).Returns(test.AsQueryable().Expression);
            _dbset.As<IQueryable<TestObj>>().Setup(x => x.ElementType).Returns(test.AsQueryable().ElementType);
            _dbset.As<IQueryable<TestObj>>().Setup(x => x.GetEnumerator()).Returns(test.AsQueryable().GetEnumerator());

            _context.Setup(x => x.Test).Returns(_dbset.Object);

            var result = _obj.GetAll();

            Assert.AreEqual(test, result.ToList());
        }
    }
}

      
        