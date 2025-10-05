namespace Assignment2.Repositories
{
    public interface IUnitOfWork
    {
        IBookRepository Books { get; }
        IUserRepository Users { get; }
        int Complete();   
    }
}
