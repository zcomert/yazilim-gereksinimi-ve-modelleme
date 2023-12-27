using System.Security.Cryptography;
using System.Text;

namespace Repositories.Services;

public static class StringEncoder
{
    public static string Encoder(this string password, int salt)
    {
        byte[] data = Encoding.UTF8.GetBytes(password + salt.ToString());
        byte[] hash = SHA256.HashData(data);
        return Convert.ToHexString(hash);
    }
}