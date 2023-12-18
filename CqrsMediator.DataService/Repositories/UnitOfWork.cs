using CqrsMediator.DataService.Data;
using CqrsMediator.DataService.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace CqrsMediator.DataService.Repositories;

public class UnitOfWork(AppDbContext context, ILogger<UnitOfWork> logger) : IUnitOfWork, IDisposable
{
    private readonly AppDbContext _dbContext = context;
    private readonly ILogger _logger = logger;

    public IDriverRepository DriverRepository { get; } = new DriverRepository(context, logger);
    public IAchievementsRepository AchievementsRepository { get; } = new AchievementRepository(context, logger);
    public async Task<bool> CompleteAsync()
    {
        var result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}
