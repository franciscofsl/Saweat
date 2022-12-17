using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Saweat.Application.Common.Interfaces;
using Saweat.Application.Contracts.Common;
using Saweat.Domain.Common;
using System.Linq.Expressions;

namespace Saweat.Infrastructure.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
{
    private readonly IDbContext _context;

    public Repository(IDbContext context)
    {
        _context = context;
    }

    public async Task InsertAsync(params TEntity[] entities)
    {
        await _context.Set<TEntity>().AddRangeAsync(entities);
    }

    public Task UpdateAsync(params TEntity[] entities)
    {
        _context.Set<TEntity>().UpdateRange(entities);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        _context.Set<TEntity>().RemoveRange(entity);
    }

    public async Task<TEntity?> FirstOrDefaultAsync(CancellationToken token = default)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(token);
    }
    public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, CancellationToken token = default)
    {
        return await _context.Set<TEntity>().Where(expression).FirstOrDefaultAsync(token);
    }

    public async Task<int> CountAsync(CancellationToken token = default)
    {
        return await _context.Set<TEntity>().CountAsync(token);
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression, CancellationToken token = default)
    {
        return await _context.Set<TEntity>().CountAsync(expression, token);
    }

    public async Task<IList<TEntity>> GetAllAsync(CancellationToken token = default)
    {
        return await _context.Set<TEntity>().ToListAsync(token);
    }

    public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, CancellationToken token = default)
    {
        return await _context.Set<TEntity>().Where(expression).ToListAsync(token);
    }

    public async Task<bool> AnyAsync(CancellationToken token = default)
    {
        return await _context.Set<TEntity>().AnyAsync(token);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, CancellationToken token = default)
    {
        return await _context.Set<TEntity>().AnyAsync(expression, token);
    }

    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(_ => _.Id == id, token);
    }

    public Task<IQueryable<TEntity>> GetQueryableAsync()
    {
        var query = _context.Set<TEntity>();
        return Task.FromResult(query.AsQueryable());
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
