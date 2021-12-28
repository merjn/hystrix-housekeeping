using System.Threading.Tasks;
using Hystrix.Application.Authentication;
using Hystrix.Domain.Entity.UserAggregate;

namespace Hystrix.Application.Service
{
    public interface IAuthenticationService
    {
        public Task<IAuthenticationResult> AuthenticateAsync(string userName);
    }
}