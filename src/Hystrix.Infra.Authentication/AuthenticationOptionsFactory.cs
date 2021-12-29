using System.Threading.Tasks;
using Hystrix.Domain.Entity.SiteConfigAggregate;
using Hystrix.Domain.Repository;

namespace Hystrix.Infra.Authentication
{
    public class AuthenticationOptionsFactory
    {
        private readonly IAsyncRepository<SiteConfig> _siteConfigRepository;

        public AuthenticationOptionsFactory(IAsyncRepository<SiteConfig> siteConfigRepository)
        {
            _siteConfigRepository = siteConfigRepository;
        }
        
        public async Task<AuthenticationOptions> CreateAuthenticationOptions()
        {
            var siteConfig = await _siteConfigRepository.FirstAsync();
            
            return new AuthenticationOptions
            {
                IsPersistent = AuthenticationOptionDefaults.IsPersistent,
                ExpiresAt = siteConfig?.SessionExpiresAt ?? AuthenticationOptionDefaults.ExpiresAt
            };
        }
    }
}