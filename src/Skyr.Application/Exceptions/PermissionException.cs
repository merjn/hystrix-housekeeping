using System;

namespace Skyr.Application.Exceptions
{
    public sealed class PermissionException : Exception
    {
        public PermissionException(string message)
            : base(message)
        {
            
        }
    }
}