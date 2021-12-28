using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification;
using Skyr.Domain.Entity;
using Skyr.Domain.Interfaces;

namespace Skyr.Application.Repository
{
    public interface IAsyncRepository<T> where T : IAggregateRoot
    {
        Task<T> FirstAsync();
        
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<T> FindAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
        
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
    }
}