using Assignment2.Data;

namespace Assignment2.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        public IBookRepository Books { get; }

        public UnitOfWork(AppDbContext appDbContext, IBookRepository books)
        {
            _appDbContext = appDbContext;
            Books = books;
        }

        public int Complete()
        {
            return _appDbContext.SaveChanges();
        }
    }
}
