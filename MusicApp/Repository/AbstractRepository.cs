using System.Collections;

public abstract class AbstractRepository<T> : IRepositoryMethods<T>
{
    protected List<T> list;

    public AbstractRepository()
    {
        list = new List<T>();
    }

    public void Create(T item)
    {
        list.Add(item);
    }

    public void DeleteAll()
    {
        list.Clear();
    }

    public abstract void DeleteOne(int id);

    public List<T> GetAll()
    {
        return list;
    }

    public abstract T GetOne(int id);

    public abstract void Update(int id, T item);

    public IEnumerator<T> GetEnumerator()
    {
        return list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}