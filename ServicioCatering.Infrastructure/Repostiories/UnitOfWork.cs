using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ServicioCatering.Infrastructure.DomainModel;
using ServicioCatering.Domain.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace ServicioCatering.Infrastructure.Repositories;

internal class UnitOfWork : IUnitOfWork
{
    private readonly DomainDbContext _dbContext;

    public UnitOfWork(DomainDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        foreach (EntityEntry entry in _dbContext.ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Modified:
                    entry.State = EntityState.Unchanged;
                    break;
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    break;
            }
        }

        await Task.CompletedTask;
    }
}
