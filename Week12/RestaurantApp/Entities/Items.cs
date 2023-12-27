using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class Items
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    [ForeignKey("Categories")]
    public int CategoryId { get; set; }
    public Categories Category { get; set; }
}