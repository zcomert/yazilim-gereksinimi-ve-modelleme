using Entities.Exceptions;
using Entities.Models;
using Entities.RequestParameters;
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

    [HttpGet] // api/products?min=300&max=500
    public IActionResult GetAllProducts([FromQuery] ProductRequestParameters p)
    {
        List<Product> model;
        if(p.Min.Equals(0) && p.Max.Equals(0))
            model = _context
                .Products
                .ToList();
        else
            
            model = p.IsValid 
                ? _context
                    .Products
                    .Where(prd => prd.Price>=p.Min && prd.Price<p.Max)
                    .ToList()
                : _context.Products.ToList();
            
            

        return Ok(model);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetOneProduct([FromRoute(Name = "id")] int id)
    {
        var model = _context
        .Products
        .SingleOrDefault(p => p.ProductId.Equals(id));

        if(model is null)
            throw new ProductNotFoundException(id);
        
        return Ok(model);
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
        return Created($"/api/products/{product.ProductId}",product); // 201
    }
}