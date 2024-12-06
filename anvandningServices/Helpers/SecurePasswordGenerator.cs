using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace anvandningServices.Helpers;

public static class SecurePasswordGenerator
{
    private static readonly byte[] _Key = Encoding.UTF8.GetBytes("ZW5zw6RrZXJueWrZWw=");

    public static string Generate(string password)
    {
        try
        { 
            using var hmac = new HMACSHA256(_Key);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            var encoded = Convert.ToBase64String(hash);
            return encoded;      
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }


    public static bool Validate(string password, string expectedHashedPassword)
    {
        try
        {
            using var hmac = new HMACSHA256(_Key);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            var encoded = Convert.ToBase64String(hash);
            return encoded == expectedHashedPassword;
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
}