using System.Security.Cryptography;
using Entities;
using Repositories.Interfaces;
using Repositories.Services;
using Repositories.Services.Exceptions;

namespace Repositories;

public class UserRepository : IRepository<User>
{
    private RepositoryDbContext dbContext;

    public UserRepository(RepositoryDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Delete(int id)
    {
        var item = GetOne(id);
        if (item is null)
            throw new NotFoundException(id);
        dbContext.Users.Remove(item);
        dbContext.SaveChanges();
    }

    public User GetOne(int id)
    {
        return dbContext.Users.SingleOrDefault(user => user.Id.Equals(id));
    }

    public void Post(User item)
    {
        if (item is null)
            throw new BadRequestException();

        var salt = RandomNumberGenerator.GetInt32(10000);

        var pass = item.Password.Encoder(salt);
        item.Password = pass;
        item.Salt = salt;
        dbContext.Users.Add(item);
        dbContext.SaveChanges();
    }

    public User GetData(string email, string password)
    {
        var user = dbContext.Users.SingleOrDefault(user => user.Email.Equals(email));
        if (user is null)
            throw new BadRequestException("Email is wrong!");

        var pass = password.Encoder(user.Salt);

        if (user.Password.Equals(pass))
            return user;
        throw new UserBadRequestException(email, password);
    }
}
