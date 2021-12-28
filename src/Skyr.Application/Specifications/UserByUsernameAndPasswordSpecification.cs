using Ardalis.Specification;
using Skyr.Domain.Entity.UserAggregate;

namespace Skyr.Application.Specifications
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