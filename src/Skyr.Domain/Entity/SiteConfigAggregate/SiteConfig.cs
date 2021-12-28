using System;
using Skyr.Domain.Interfaces;

namespace Skyr.Domain.Entity.SiteConfigAggregate
{
    public class SiteConfig : IAggregateRoot
    {
        public DateTime SessionExpiresAt { get; set; }
    }
}