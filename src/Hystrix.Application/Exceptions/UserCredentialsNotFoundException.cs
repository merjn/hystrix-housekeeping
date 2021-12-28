using System;

namespace Hystrix.Application.Exceptions
{
    public class UserCredentialsNotFoundException : Exception
    {
        public UserCredentialsNotFoundException(string message)
            : base(message)
        {
            
        }
    }
}