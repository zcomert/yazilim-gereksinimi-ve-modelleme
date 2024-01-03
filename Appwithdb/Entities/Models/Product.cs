using System.ComponentModel.DataAnnotations;

namespace Entities.Models;
public class Product : IComparable<Product>
{
    public int ProductId { get; set; }
    
    [Required(ErrorMessage ="ProductName is required!")]
    public String? ProductName { get; set; } = string.Empty;
    
    [Range(10,900, ErrorMessage = "Price must be between 10 and 900!")]
    public int Price { get; set; }

    public int CompareTo(Product? other)
    {
        return this.ProductName.CompareTo(other.ProductName);
    }
}