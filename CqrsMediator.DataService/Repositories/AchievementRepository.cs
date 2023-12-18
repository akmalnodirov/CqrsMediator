using CqrsMediator.DataService.Data;
using CqrsMediator.DataService.Repositories.Interfaces;
using CqrsMediator.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CqrsMediator.DataService.Repositories;

internal class AchievementRepository(AppDbContext context, ILogger logger) : GenericRepository<Achievements>(context, logger), IAchievementsRepository
{
    public async Task<Achievements?> GetDriverAchievementsAsync(Guid driverId)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.DriverId == driverId);
    }

    public override async Task<IEnumerable<Achievements>> All()
    {
        return await _dbSet.Where(x => x.Status == 1)
            .AsNoTracking()
            .AsSplitQuery()
            .OrderBy(x => x.AddedDate)
            .ToListAsync();
    }

    public override async Task<bool> Delete(Guid id)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            return true;
        }

        return false;
    }

    public override async Task<bool> Update(Achievements achievement)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == achievement.Id);
        if (entity != null)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            entity.DriverId = achievement.DriverId;
            entity.FastestLap = achievement.FastestLap;
            entity.Status = achievement.Status;
            entity.PolePosition = achievement.PolePosition;
            entity.RaceWins = achievement.RaceWins;
            entity.WorldChampionship = achievement.WorldChampionship;

            return true;
        }

        return false;
    }

}
