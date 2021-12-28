using System;

namespace Hystrix.Application.Exceptions
{
    public sealed class PermissionException : Exception
    {
        public PermissionException(string message)
            : base(message)
        {
            
        }
    }
}