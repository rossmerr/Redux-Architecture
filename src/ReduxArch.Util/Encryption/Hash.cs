using System;
using System.Text;
using System.Security.Cryptography;

namespace ReduxArch.Util.Encryption
{
    public class Hash
    {
        public static string ComputeHash(string plainText, HashAlgorithm hashAlgorithm, string salt)
        {
            System.Security.Cryptography.HashAlgorithm hash;

            switch (hashAlgorithm)
            {
                case HashAlgorithm.SHA1:
                    hash = new SHA1Managed();
                    break;

                case HashAlgorithm.SHA256:
                    hash = new SHA256Managed();
                    break;

                case HashAlgorithm.SHA384:
                    hash = new SHA384Managed();
                    break;

                case HashAlgorithm.SHA512:
                    hash = new SHA512Managed();
                    break;

                default:
                    hash = new MD5CryptoServiceProvider();
                    break;
            }

            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);

            byte[] plainTextWithSalt = Encoding.UTF8.GetBytes(plainText + salt);
            byte[] hashBytes = hash.ComputeHash(plainTextWithSalt);
            string hashValue = System.Convert.ToBase64String(hashBytes);


            ////// Compute hash value of our plain text with appended salt.
            //byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);

            ////// Create array which will hold hash and original salt bytes.
            //byte[] hashWithSaltBytes = new byte[hashBytes.Length + saltBytes.Length];

            //// Copy hash bytes into resulting array.
            //for (int i = 0; i < hashBytes.Length; i++)
            //{
            //    hashWithSaltBytes[i] = hashBytes[i];
            //}

            //// Append salt bytes to the result.
            //for (int i = 0; i < saltBytes.Length; i++)
            //{
            //    hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];
            //}
            //// Convert result into a base64-encoded string.
            //string hashValue = Convert.ToBase64String(hashWithSaltBytes);

            return hashValue;
        }

        public static string Salt()
        {
            // Define min and max salt sizes.
            int minSaltSize = 4;
            int maxSaltSize = 8;

            // Generate a random number for the size of the salt.
            Random random = new Random();
            int saltSize = random.Next(minSaltSize, maxSaltSize);

            // Allocate a byte array, which will hold the salt.
            byte[] saltBytes = new byte[saltSize];

            // Initialize a random number generator.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            // Fill the salt with cryptographically strong byte values.
            rng.GetNonZeroBytes(saltBytes);
            return System.Convert.ToBase64String(saltBytes);
        }
    }
}