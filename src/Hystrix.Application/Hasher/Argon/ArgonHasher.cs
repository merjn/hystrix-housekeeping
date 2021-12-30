using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Hystrix.Domain.Hasher;
using Konscious.Security.Cryptography;

namespace Hystrix.Application.Hasher.Argon
{
    public class ArgonHasher : IAsyncHasher
    {
        public async Task<string> HashAsync(string plaintext)
        {
            using var argon2Id = new Argon2id(Encoding.UTF8.GetBytes(plaintext));
            
            argon2Id.Salt = SaltGenerator.CreateSalt();
            argon2Id.DegreeOfParallelism = DefaultArgonOptions.Parallelism;
            
            var hash = await argon2Id.GetBytesAsync(16);

            return Convert.ToBase64String(hash);
        }
    }
}