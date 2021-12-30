using System;
using System.Security.Cryptography;

namespace Hystrix.Application.Hasher
{
    public static class SaltGenerator
    {
        /// <summary>
        /// Generate a pseudo-random salt.
        ///
        /// Using RNGCryptoServiceProvider because it generates secure pseudo-random bytes, according to
        /// https://cheatsheetseries.owasp.org/cheatsheets/Cryptographic_Storage_Cheat_Sheet.html.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static byte[] CreateSalt(int size = 16)
        {
            Span<byte> buffer = stackalloc byte[size];
            
            using var rng = new RNGCryptoServiceProvider();
            
            rng.GetBytes(buffer);

            return buffer.ToArray();
        }
    }
}