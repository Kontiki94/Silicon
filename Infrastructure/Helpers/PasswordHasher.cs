using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Helpers
{
    public class PasswordHasher
    {
        // The size of the salt.
        private const int SaltSize = 32;
        // Private key used in the HMAC-algorithm to create a hashed password otogether with the salt.
        private const string SecurityKey = "16";

        /// <summary>
        /// Creates a instance of HMACSHA3_512 with the securitykey, then the salt is introduced to the HMAC-object.
        /// Converts the password to bytes and the HMACSHA3_512 algo is used to calculate the hashvalue.
        /// </summary>
        /// <param name="password">The input password from the user</param>
        /// <returns>Returns salt and hash as 64base-coded strings</returns>
        public static (string, string) GenerateSecurePassword(string password)
        {
            byte[] salt = GenerateSalt();


            using var hmac = new HMACSHA3_512(Encoding.UTF8.GetBytes(SecurityKey));
            hmac.Key = salt;
            var hashedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return (Convert.ToBase64String(salt), Convert.ToBase64String(hashedPassword));
        }

        /// <summary>
        /// Validates a password against a already generated hashvalue
        /// Hash and salt converts to byte-arrays
        /// Creates a instance of the HMAC-algo with the SecurityKey as a key and the salt is assigned the HMAC-object.
        /// The password is converted to bytes and HMAC calculate the hash value.
        /// Lastely, the two hashvalues are compared against each other
        /// </summary>
        /// <param name="password">The input password from the user</param>
        /// <param name="hash">The calulated hash</param>
        /// <param name="salt">Salting</param>
        /// <returns>True if valid, else false</returns>
        public static bool ValidateSecurePassword(string password, string hash, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            byte[] hashBytes = Convert.FromBase64String(hash);

            using var hmac = new HMACSHA3_512(Encoding.UTF8.GetBytes(SecurityKey));
            hmac.Key = saltBytes;
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return AreHashesEqual(hashBytes, computedHash);
        }

        /// <summary>
        /// Generates a random salt based on the SaltSize.
        /// </summary>
        /// <returns></returns>
        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        /// <summary>
        /// Compares two hashvalues against each other. 
        /// First we controll the length of the two byte-arrays against each other, secondly we control the byte separately
        /// </summary>
        /// <param name="hash1">Represents the saved hash-value</param>
        /// <param name="hash2">Represents the new (input) hash-value</param>
        /// <returns></returns>
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
