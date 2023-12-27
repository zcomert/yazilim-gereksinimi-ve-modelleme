using Entities;
using Repositories.Interfaces;

namespace Repositories;

public class OrdersRepository : IRepository<Order>
{
    private List<Order> orders;

    public OrdersRepository(List<Order> orders)
    {
        this.orders = orders;
    }

    public void Delete(int id)
    {
        var item = GetOne(id);
        orders.Remove(item);
    }

    public Order GetOne(int id)
    {
        return orders.SingleOrDefault(cat => cat.Id.Equals(id));
    }

    public void Post(Order item)
    {
        orders.Add(item);
    }
}