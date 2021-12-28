using System.Collections.Generic;
using System.Security.Claims;
using Skyr.Application.Authentication;

namespace Skyr.Authentication
{
    public class CookieAuthenticationResult : IAuthenticationResult
    {
        public IReadOnlyList<Claim> Claims { get; init; }
    }
}