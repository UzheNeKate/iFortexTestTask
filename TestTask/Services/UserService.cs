using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _dbContext;

    public UserService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<User> GetUser()
    {
       return Task.FromResult(
           _dbContext.Users.OrderByDescending(x => x.Orders.Count).First());
    }

    public Task<List<User>> GetUsers()
    {
        return Task.FromResult(
            _dbContext.Users.Where(x => x.Status == Enums.UserStatus.Inactive).ToList());
    }
}