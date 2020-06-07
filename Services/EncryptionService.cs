using System;
using System.Security.Cryptography;
using System.Text;

namespace debt_calculator_api.Services
{
    public static class EncryptionService
    {
        public static string PBKDF2Hash(string password)
        {
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, 32)
            {
                IterationCount = 10000
            };

            byte[] hash = rfc2898DeriveBytes.GetBytes(20);

            byte[] salt = rfc2898DeriveBytes.Salt;

            return Convert.ToBase64String(salt) + "|" + Convert.ToBase64String(hash);
        }
    }
}