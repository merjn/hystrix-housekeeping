using System.Threading.Tasks;
using Hystrix.Domain.Entity.UserAggregate;

namespace Hystrix.Domain.Authentication
{
    public interface IAuthenticationService
    {
        public Task<IAuthenticationResult> AuthenticateAsync(string userName);
    }
}