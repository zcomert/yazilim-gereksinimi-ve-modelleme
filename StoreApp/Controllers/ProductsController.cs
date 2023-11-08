using Microsoft.AspNetCore.Mvc;
using StoreApp.Repositories;

namespace StoreApp.Controllers;

[ApiController]
[Route("/api/products")]
public class ProductsController : ControllerBase
{
    private readonly ProductRepository _productRepository;

    public ProductsController(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        var products = _productRepository.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetOneProduct(int id)
    {
        var product = _productRepository.GetOneProduct(id);
        return Ok(product);
    }
}