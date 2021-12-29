using System.Collections.Generic;
using System.Security.Claims;
using Hystrix.Domain.Service;

namespace Hystrix.Infra.Authentication
{
    public class CookieAuthenticationResult : IAuthenticationResult
    {
        public IReadOnlyList<Claim> Claims { get; init; }
    }
}