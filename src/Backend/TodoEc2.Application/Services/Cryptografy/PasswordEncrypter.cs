﻿using System.Security.Cryptography;
using System.Text;

namespace TodoEc2.Application.Services.Cryptografy
{
    public class PasswordEncrypter
    {
        public string Encrypt(string password)
        {
            var newPassword = $"{password}ABC";

            var bytes = Encoding.UTF8.GetBytes(password);
            var hashBytes = SHA512.HashData(bytes);

            return StringBytes(hashBytes);
        }

        private static string StringBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }

            return sb.ToString();
        }
    }
}
