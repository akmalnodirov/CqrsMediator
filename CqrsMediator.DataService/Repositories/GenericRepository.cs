using CqrsMediator.DataService.Data;
using CqrsMediator.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CqrsMediator.DataService.Repositories;

public class GenericRepository<T>(AppDbContext context, ILogger logger) : IGenericRepository<T> where T : class
{
    public readonly ILogger _logger = logger;
    protected AppDbContext _context = context;
    internal DbSet<T> _dbSet = context.Set<T>();

    public async virtual Task<bool> Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        return true;
    }

    public async virtual Task<IEnumerable<T>> All()
    {
        throw new NotImplementedException();
    }

    public async virtual Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async virtual Task<T?> GetById(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async virtual Task<bool> Update(T entity)
    {
        throw new NotImplementedException();
    }
}
