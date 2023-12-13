using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace ProductApi.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly RepositoryContext _context;

    public ProductsController(RepositoryContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        throw new Exception("GetAllProducts booowww!");
        return Ok(_context.Products);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetOneProduct([FromRoute(Name = "id")] int id)
    {
        return Ok(_context
        .Products
        .SingleOrDefault(p => p.ProductId.Equals(id)));
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteOneProduct([FromRoute(Name = "id")] int id)
    {
        var entity = _context.Products.SingleOrDefault(p => p.ProductId.Equals(id));
        _context.Products.Remove(entity);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateOneProduct([FromRoute(Name = "id")] int id,
        [FromBody] Product product)
    {
        var entity = _context.Products.SingleOrDefault(p => p.ProductId.Equals(id));
        if (entity is not null)
        {
            entity.ProductName = product.ProductName;
            entity.Price = product.Price;
            _context.Products.Update(entity);
            _context.SaveChanges();
        }
        return NoContent();
    }

    [HttpPost]
    public IActionResult CreateOneProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return NoContent();
    }
}