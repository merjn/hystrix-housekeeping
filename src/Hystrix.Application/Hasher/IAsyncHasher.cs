using System.Threading.Tasks;

namespace Hystrix.Application.Hasher
{
    public interface IAsyncHasher
    {
        /// <summary>
        /// Produces hashed data from a plaintext.
        /// </summary>
        /// <param name="plaintext"></param>
        /// <returns></returns>
        public Task<string> HashAsync(string plaintext);
    }
}