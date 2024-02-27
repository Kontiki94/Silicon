using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Helpers
{
    public class PasswordHasher
    {
        private const int SaltSize = 32;
        private const string SecurityKey = "16";

        public static (string, string) GenerateSecurePassword(string password)
        {
            byte[] salt = GenerateSalt();


            using var hmac = new HMACSHA3_512(Encoding.UTF8.GetBytes(SecurityKey));
            hmac.Key = salt;
            var hashedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return (Convert.ToBase64String(salt), Convert.ToBase64String(hashedPassword));
        }

        public static bool ValidateSecurePassword(string password, string hash, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            byte[] hashBytes = Convert.FromBase64String(hash);

            using var hmac = new HMACSHA3_512(Encoding.UTF8.GetBytes(SecurityKey));
            hmac.Key = saltBytes;
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return AreHashesEqual(hashBytes, computedHash);
        }

        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        private static bool AreHashesEqual(byte[] hash1, byte[] hash2)
        {
            if (hash1.Length != hash2.Length)
                return false;

            for (int i = 0; i < hash1.Length; i++)
            {
                if (hash1[i] != hash2[i])
                    return false;
            }
            return true;
        }
       
    }
}
