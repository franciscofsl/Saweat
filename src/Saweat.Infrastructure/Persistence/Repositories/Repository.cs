using Microsoft.EntityFrameworkCore;
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

    public async Task<TEntity> FirstOrDefaultAsync(Specification<TEntity>? specification = default, CancellationToken token = default)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();
        query = query.AsNoTracking();

        if (specification is null) return await query.FirstOrDefaultAsync(token);

        query = query.Where(specification.Expression);

        return await query.FirstOrDefaultAsync(token);
    }
    
    public async Task<IList<TEntity>> GetAllAsync(Specification<TEntity>? specification = default, CancellationToken token = default)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();
        query = query.AsNoTracking();

        if (specification is null) return await query.ToListAsync(token);

        query = query.Where(specification.Expression);

        return await query.ToListAsync(token);
    }

    public async Task<int> CountAsync(Specification<TEntity>? specification = default, CancellationToken token = default)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();
        return specification is not null
            ? await query.CountAsync(specification.Expression, token)
            : await query.CountAsync(token);
    }

    public async Task<bool> ExistsAsync(Specification<TEntity>? specification = default, CancellationToken token = default)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();
        return specification is not null
            ? await query.AnyAsync(specification.Expression, token)
            : await query.AnyAsync(token);
    }

    public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        var query = _context.Set<TEntity>();
        return await query.FirstOrDefaultAsync(_ => _.Id == id, token);
    } 
    
    public async Task<decimal> SumAsync(Expression<Func<TEntity, decimal>> selector, Specification<TEntity>? specification = default, CancellationToken token = default)
    {
        var query = _context.Set<TEntity>();
        return specification != null
            ? await query.Where(specification.Expression).SumAsync(selector, token)
            : await query.SumAsync(selector, token);
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
