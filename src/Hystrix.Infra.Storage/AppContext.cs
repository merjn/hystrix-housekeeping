using Hystrix.Domain.Entity.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace Hystrix.Infra.Storage
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        
    }
}