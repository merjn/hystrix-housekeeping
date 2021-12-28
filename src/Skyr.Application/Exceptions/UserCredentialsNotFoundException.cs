using System;

namespace Skyr.Application.Exceptions
{
    public class UserCredentialsNotFoundException : Exception
    {
        public UserCredentialsNotFoundException(string message)
            : base(message)
        {
            
        }
    }
}