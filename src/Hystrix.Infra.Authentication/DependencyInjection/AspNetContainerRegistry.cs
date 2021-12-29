using System;
using Microsoft.Extensions.DependencyInjection;
using Hystrix.Domain.Service;

namespace Hystrix.Infra.Authentication.DependencyInjection
{
    public static class AspNetContainerRegistry
    {
        public static void ConfigureServices(IServiceCollection collection)
        {
            RegisterAuthenticationService(collection);
        }

        private static void RegisterAuthenticationService(IServiceCollection collection)
        {
            collection.AddScoped<AuthenticationOptionsFactory>();

            collection.AddScoped<IAuthenticationService, AspNetCookieAuthenticationService>();
        }
    }
}