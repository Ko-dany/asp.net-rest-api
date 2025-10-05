using Assignment2.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Repositories
{
    public interface IUserRepository
    {
        DbSet<User> GetUserDB();
    }
}
