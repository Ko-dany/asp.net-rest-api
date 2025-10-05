namespace Assignment2.Repositories
{
    public interface IUnitOfWork
    {
        IBookRepository Books { get; }
        int Complete();   
    }
}
