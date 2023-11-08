namespace StoreApp.Models;

public class Product : IComparable
{
    public int Id { get; set; }
    public String? ProductName { get; set; }
    public Double Price { get; set; }
    public int CompareTo(object? obj)
    {
        return this.Price.CompareTo(((Product)obj).Price);
    }
}