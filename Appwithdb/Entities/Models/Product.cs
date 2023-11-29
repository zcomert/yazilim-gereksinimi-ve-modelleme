namespace Entities.Models;
public class Product
{
    public int ProductId { get; set; }
    public String? ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
}