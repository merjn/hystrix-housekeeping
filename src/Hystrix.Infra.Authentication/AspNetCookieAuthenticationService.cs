using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Hystrix.Domain.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using IAuthenticationService = Hystrix.Domain.Authentication.IAuthenticationService;

namespace Hystrix.Infra.Authentication
{
    public class AspNetCookieAuthenticationService : IAuthenticationService
    {
        private readonly AuthenticationOptionsFactory _authenticationOptionsFactory;
        private readonly HttpContext _httpContext;

        public AspNetCookieAuthenticationService(AuthenticationOptionsFactory authenticationOptionsFactory, HttpContext httpContext)
        {
            _authenticationOptionsFactory = authenticationOptionsFactory;
            _httpContext = httpContext;
        }
        
        public async Task<IAuthenticationResult> AuthenticateAsync(string userName)
        {
            var authenticationOptionsTask = _authenticationOptionsFactory.CreateAuthenticationOptions();
            
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, userName)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(claimsIdentity);

            var authenticationOptions = await authenticationOptionsTask;

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = authenticationOptions.ExpiresAt,
                IsPersistent = authenticationOptions.IsPersistent
            };

            await _httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

            return new CookieAuthenticationResult
            {
                Claims = claims.AsReadOnly()
            };
        }
    }
}