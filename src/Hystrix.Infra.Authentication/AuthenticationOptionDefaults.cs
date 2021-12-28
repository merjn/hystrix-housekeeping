using System;

namespace Hystrix.Infra.Authentication
{
    public class AuthenticationOptionDefaults
    {
        public const bool IsPersistent = true;

        public static readonly DateTime ExpiresAt = DateTime.Now.AddMinutes(30);
    }
}