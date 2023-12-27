using Entities;
using Repositories.Interfaces;
using Repositories.Services;

namespace Repositories;

public class ItemRepository : IRepository<Items>
{
    private RepositoryDbContext dbContext;

    public ItemRepository(RepositoryDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Delete(int id)
    {
        var item = GetOne(id);
        dbContext.Items.Remove(item);
        dbContext.SaveChanges();
    }

    public Items GetOne(int id)
    {
        return dbContext.Items.SingleOrDefault(cat => cat.Id.Equals(id));
    }

    public List<Items> GetAll()
    {
        return dbContext.Items.ToList();
    }

    public void Post(Items item)
    {
        dbContext.Items.Add(item);
        dbContext.SaveChanges();
    }
}