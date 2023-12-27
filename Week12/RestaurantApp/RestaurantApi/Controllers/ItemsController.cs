using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace RestaurantApi.Controller;

[ApiController]
[Route("api/items")]
public class ItemsController : ControllerBase
{
    private ItemRepository repository;

    public ItemsController(ItemRepository repository)
    {
        this.repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(repository.GetAll());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetOne(int id)
    {
        var item = repository.GetOne(id);
        if (item is null)
            throw new Exception("");
        return Ok(item);
    }

    [HttpPost]
    public IActionResult Post(string name, string description, decimal price, int categoryId)
    {
        repository.Post(new Items()
        {
            Name = name,
            Description = description,
            Price = price,
            CategoryId = categoryId
        });
        return Ok("Item added!");
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        repository.Delete(id);
        return NoContent();
    }

}