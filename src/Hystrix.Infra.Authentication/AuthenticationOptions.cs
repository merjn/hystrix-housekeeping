using System;

namespace Hystrix.Infra.Authentication
{
    public class AuthenticationOptions
    {
        public bool IsPersistent { get; set; }
        
        public DateTime ExpiresAt { get; init; }
    }
}