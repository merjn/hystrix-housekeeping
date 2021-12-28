using Ardalis.Specification;
using Hystrix.Domain.Entity.UserAggregate;

namespace Hystrix.Application.Specifications
{
    public sealed class UserByUsernameAndPasswordSpecification : Specification<User>, ISingleResultSpecification
    {
        public UserByUsernameAndPasswordSpecification(string username, string password)
        {
            Query.Where(x => x.Username == username)
                .Where(x => x.Password == password);
        }
    }
}