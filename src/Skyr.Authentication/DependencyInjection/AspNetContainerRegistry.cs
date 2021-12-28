using System;
using Microsoft.Extensions.DependencyInjection;
using Skyr.Application.Service;

namespace Skyr.Authentication.DependencyInjection
{
    public static class AspNetContainerRegistry
    {
        public static void ConfigureServices(IServiceCollection collection)
        {
            RegisterAuthenticationService(collection);
        }

        private static void RegisterAuthenticationService(IServiceCollection collection)
        {
            // TODO: Get all authentication options from the database.
            collection.AddScoped<AuthenticationOptionsFactory>();

            collection.AddScoped<IAuthenticationService, AspNetCookieAuthenticationServiceImpl>();
        }
    }
}