using System;
using Hystrix.Domain.Interfaces;

namespace Hystrix.Domain.Entity.SiteConfigAggregate
{
    public class SiteConfig : IAggregateRoot
    {
        public DateTime SessionExpiresAt { get; set; }
    }
}