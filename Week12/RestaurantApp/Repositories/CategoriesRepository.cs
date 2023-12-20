using Entities;
using Repositories.Interfaces;

namespace Repositories;

public class CategoriesRepository : IRepository<Categories>
{
    private List<Categories> categories;

    public CategoriesRepository(List<Categories> categories)
    {
        this.categories = categories;
    }

    public void Delete(int id)
    {
        var item = GetOne(id);
        categories.Remove(item);
    }

    public Categories GetOne(int id)
    {
        return categories.SingleOrDefault(cat => cat.Id.Equals(id));
    }

    public void Post(Categories item)
    {
        categories.Add(item);
    }
}