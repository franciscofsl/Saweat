using Microsoft.EntityFrameworkCore;

namespace Saweat.Application.Contracts.Common;

public interface IDbContext : IDisposable
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
