using System.Threading.Tasks;
using Hystrix.Application.Hasher;

namespace Hystrix.Infra.Hashing
{
    public class ArgonPasswordHasher : IAsyncHasher
    {
        public Task<string> HashAsync(string plaintext)
        {
            throw new System.NotImplementedException();
        }
    }
}