public interface IRepositoryMethods<T> : IEnumerable<T>
{
    public T GetOne(int id);
    public List<T> GetAll(int id);
    public void Create(T item);
    public void Update(int id, T item);
    public void DeleteOne(int id);
    public void DeleteAll();
}