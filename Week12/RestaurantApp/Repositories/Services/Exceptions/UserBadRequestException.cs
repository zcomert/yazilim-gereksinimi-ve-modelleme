namespace Repositories.Services.Exceptions;

public sealed class UserBadRequestException : BadRequestException
{
    public UserBadRequestException(string email, string password) : base($"{email} or {password} is not valid!")
    { }
}