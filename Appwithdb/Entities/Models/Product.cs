namespace Entities.Models;
public class Product : IComparable<Product>
{
    public int ProductId { get; set; }
    public String? ProductName { get; set; } = string.Empty;
    public int Price { get; set; }

    public int CompareTo(Product? other)
    {
        return this.ProductName.CompareTo(other.ProductName);
    }
}