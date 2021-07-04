using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace WebTask1.Models
{
    public static class GenerationId
    {
        public static string GenerateHash()
        {
            var bytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }

            string hash = BitConverter.ToString(bytes).Replace("-", "").ToLower();

            return hash;
        }
    }
}