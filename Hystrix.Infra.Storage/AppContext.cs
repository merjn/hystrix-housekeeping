using Hystrix.Domain.Entity.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace Hystrix.Infra.Storage
{
    public class AppContext : DbContext
    {
        #region User aggregate
        public DbSet<User> Users { get; set; }
        #endregion

        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}