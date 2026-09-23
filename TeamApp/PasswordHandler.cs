using System.Security.Cryptography;
using System.Text;
using Isopoh.Cryptography.Argon2;

namespace TeamApp;

public class PasswordHandler
{
    public static string HashPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(16);

        var config = new Argon2Config
        {
            Type = Argon2Type.DataIndependentAddressing,
            Version = Argon2Version.Nineteen,
            TimeCost = 3,
            MemoryCost = 65536,
            Lanes = 4,
            Threads = 4,
            Password = Encoding.UTF8.GetBytes(password),
            Salt = salt,
            HashLength = 32
        };

        using var argon2 = new Argon2(config);
        using var hash = argon2.Hash();
        
        return config.EncodeString(hash.Buffer);
    }

    public static bool VerifyPassword(string password, string storedHash)
    {
        return Argon2.Verify(storedHash, password);
    }
}