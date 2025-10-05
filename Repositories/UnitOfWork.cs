using Assignment2.Data;

namespace Assignment2.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        public IBookRepository Books { get; }
        public IUserRepository Users { get; }

        public UnitOfWork(AppDbContext appDbContext, IBookRepository books, IUserRepository users)
        {
            _appDbContext = appDbContext;
            Books = books;
            Users = users;
        }

        public int Complete()
        {
            return _appDbContext.SaveChanges();
        }
    }
}
