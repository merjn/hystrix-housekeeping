using System.Threading.Tasks;
using Skyr.Application.Authentication;
using Skyr.Domain.Entity.UserAggregate;

namespace Skyr.Application.Service
{
    public interface IAuthenticationService
    {
        public Task<IAuthenticationResult> AuthenticateAsync(string userName, string password);
    }
}