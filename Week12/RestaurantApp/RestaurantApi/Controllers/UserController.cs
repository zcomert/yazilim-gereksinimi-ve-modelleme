using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private UserRepository repository;

    public UserController(UserRepository repository)
    {
        this.repository = repository;
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        repository.Delete(id);
        return NoContent();
    }

    [HttpGet("{id:int}")]
    public IActionResult GetOne(int id)
    {
        var data = repository.GetOne(id);
        if (data is null)
            return NotFound("Item not found!");
        return Ok(data);
    }

    [HttpPost("register")]
    public IActionResult Register(User item)
    {
        repository.Post(item);
        return Created("Item created!", item);
    }

    [HttpPost("login")]
    public IActionResult Login(string email, string password)
    {
        var user = repository.GetData(email, password);
        if (user is null)
            return NotFound();
        return Ok(user);
    }
}