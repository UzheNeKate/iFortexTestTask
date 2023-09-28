using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services;

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _dbContext;

    public OrderService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Order> GetOrder()
    {
        return Task.FromResult(
            _dbContext.Orders.OrderByDescending(x => x.Quantity * x.Price).First());
    }

    public Task<List<Order>> GetOrders()
    {
        return Task.FromResult(
            _dbContext.Orders.Where(x => x.Quantity > 10).ToList());
    }
}