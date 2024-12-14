using System.Threading;
using System.Threading.Tasks;

namespace ServicioCatering.Domain.Abstractions;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken cancellationToken = default);
    Task RollbackAsync(CancellationToken cancellationToken = default);
}
