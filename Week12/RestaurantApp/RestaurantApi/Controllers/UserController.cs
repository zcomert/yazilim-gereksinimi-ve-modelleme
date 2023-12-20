using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Services.Exceptions;

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
            throw new NotFoundException(id);
        return Ok(data);
    }

    [HttpPost("register")]
    public IActionResult Register(string username, string email, string password)
    {
        var newUser = new User()
        {
            Username = username,
            Email = email,
            Password = password
        };
        repository.Post(newUser);
        return Created("Item created!", newUser);
    }

    [HttpPost("login")]
    public IActionResult Login(string email, string password)
    {
        var user = repository.GetData(email, password);
        if (user is null)
            throw new BadRequestException();
        return Ok(user);
    }
}