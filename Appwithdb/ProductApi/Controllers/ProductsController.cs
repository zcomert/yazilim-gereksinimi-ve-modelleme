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

    // api/products/orderbyproductname
    [HttpGet("orderbyproductname")]
    public IActionResult OrderByProductName()
    {

        // var list = _context.Products.ToList();
        // list.Sort();

        // // dot per line
        // return Ok(list);
        
        var model = _context
            .Products
            .OrderBy(prd => prd.ProductName)
            .ToList();
        return Ok(model);
    }

    // api/products/orderbyprice?direction=asc
    [HttpGet("orderbyprice")]
    public IActionResult OrderByPrice([FromQuery(Name ="direction")] string direction="asc")
    {
        var model = new List<Product>();
        switch (direction)
        {
            case "asc":
                model = _context.Products.OrderBy(p => p.Price).ToList();
                break;
            case "desc":
                model = _context.Products.OrderByDescending(p => p.Price).ToList();
                break;
            default:
                return BadRequest(); // 400
        }
        return Ok(model);
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
        
        if(entity is null)
            throw new ProductNotFoundException(id);
        
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

    [HttpPost("createall")]
    public IActionResult CreateAll([FromBody] List<Product> products)
    {
        // ürünleri dolaş ve ekle 
        // _context.Products.AddRange(products);
        foreach (var product in products)
        {
            _context.Products.Add(product);
        }
        
        // Kayıtları kalıcı hale getir
        _context.SaveChanges();
        
        return Created("api/products", products);
    }

    [HttpPut("changeprice/{rate}")] // api/products/changeprice
    public IActionResult UpdateAllPrice([FromRoute(Name ="rate")] decimal rate)
    {
        var products = _context.Products.ToList();
        foreach (var product in products)
        {
            product.Price += (int)(product.Price * (rate/100));
        }
        _context.SaveChanges();
        return NoContent();
    }
}