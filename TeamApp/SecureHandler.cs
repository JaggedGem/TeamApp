using System.Security.Cryptography;
using System.Text;
using Isopoh.Cryptography.Argon2;

namespace TeamApp;

public class SecureHandler
{
    public static string HashPassword(string password) {
        byte[] salt = RandomNumberGenerator.GetBytes(16);

        var config = new Argon2Config {
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

    public static bool VerifyPassword(string password, string storedHash) {
        return Argon2.Verify(storedHash, password);
    }

    public static byte[] GenerateMasterKey() {
        return RandomNumberGenerator.GetBytes(32);
    }

    public static (byte[], byte[], byte[]) Encrypt(byte[] masterKey, byte[] data) {
        byte[] nonce = RandomNumberGenerator.GetBytes(12);
        byte[] ciphertext = new byte[data.Length];
        byte[] tag = new byte[16];

        using (var aes = new AesGcm(masterKey, 16)) {
            aes.Encrypt(nonce, data, ciphertext, tag);
        }

        return (nonce, ciphertext, tag);
    }

    public static byte[] Decrypt(byte[] masterKey, byte[] nonce, byte[] ciphertext, byte[] tag) {
        byte[] plaintext = new byte[ciphertext.Length];
        using (var aes = new AesGcm(masterKey, 16)) {
            aes.Decrypt(nonce, ciphertext, tag, plaintext);
        }

        return plaintext;
    }

    public static (byte[], byte[]) GenerateEncryptionKey(string password) {
        byte[] encryptionSalt = RandomNumberGenerator.GetBytes(16);

        byte[] keyEncryptionKey = Rfc2898DeriveBytes.Pbkdf2(
            password,
            encryptionSalt,
            600_000,
            HashAlgorithmName.SHA256,
            32
        );

        return (encryptionSalt, keyEncryptionKey);
    }

    // Used to generate an encryption key during the login process
    public static byte[] GenerateEncryptionKey(string password, byte[] encryptionSalt) {
        byte[] keyEncryptionKey = Rfc2898DeriveBytes.Pbkdf2(
            password,
            encryptionSalt,
            600_000,
            HashAlgorithmName.SHA256,
            32
        );

        return keyEncryptionKey;
    }
}