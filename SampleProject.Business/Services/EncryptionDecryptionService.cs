using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Business.Services
{
    public static class EncryptionDecryptionService
    {
        private const string salt = "syedjunaidhanif@gmail.com";
        public static string Encryption(string planText)
        {

            //Convert the salted password to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(planText + salt);

            //Use hash algorithm to calulate hash
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);

            //Return the hash as a base64 encoded string to be compared and stored
            return Convert.ToBase64String(hash);
        }
    }
}
