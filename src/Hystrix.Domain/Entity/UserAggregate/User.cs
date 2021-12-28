using Hystrix.Domain.Interfaces;
using Hystrix.Domain.Permission;

namespace Hystrix.Domain.Entity.UserAggregate
{
    public class User : BaseEntity, IAggregateRoot
    {
        public string Username { get; init; }
        
        public string Password { get; init; }

        public bool HasPermission(PermissionEnum permission)
        {
            return true;
        }
    }
}