using System;

namespace Skyr.Authentication
{
    public class AuthenticationOptions
    {
        public bool IsPersistent { get; set; }
        
        public DateTime ExpiresAt { get; init; }
    }
}