using Saweat.Domain.Common;
using System.Linq.Expressions;

namespace Saweat.Application.Common.Interfaces;

public interface IRepository<TEntity> : IRepository where TEntity : BaseEntity, new()
{
    Task InsertAsync(params TEntity[] entities);
    Task UpdateAsync(params TEntity[] entities);
    Task DeleteAsync(Guid id);
    Task<IList<TEntity>> GetAllAsync(CancellationToken token = default);
    Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, CancellationToken token = default);
    Task<TEntity> FirstOrDefaultAsync(CancellationToken token = default);
    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, CancellationToken token = default);
    Task<int> CountAsync(CancellationToken token = default);
    Task<int> CountAsync(Expression<Func<TEntity, bool>> expression, CancellationToken token = default);
    Task<bool> AnyAsync(CancellationToken token = default);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, CancellationToken token = default);
    Task<TEntity> GetByIdAsync(Guid id, CancellationToken token = default); 
    Task<IQueryable<TEntity>> GetQueryableAsync();
    Task SaveChangesAsync();
}

public interface IReadOnlyRepository<TEntity> : IRepository where TEntity : BaseEntity, new()
{
    Task<IList<TEntity>> GetAllAsync(Specification<TEntity> specification = default, CancellationToken token = default);
    Task<TEntity> FirstOrDefaultAsync(Specification<TEntity> specification = default, CancellationToken token = default);
    Task<int> CountAsync(Specification<TEntity> specification = default, CancellationToken token = default);
    Task<bool> ExistsAsync(Specification<TEntity> specification = default, CancellationToken token = default);
    Task<TEntity> GetByIdAsync(Guid id, CancellationToken token = default);
    Task<decimal> SumAsync(Expression<Func<TEntity, decimal>> selector, Specification<TEntity> specification = default, CancellationToken token = default);
    Task<IQueryable<TEntity>> GetQueryableAsync();
}

public interface IRepository
{
}
