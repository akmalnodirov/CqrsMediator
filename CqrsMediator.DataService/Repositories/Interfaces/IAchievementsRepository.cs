using CqrsMediator.Entities.DbSet;

namespace CqrsMediator.DataService.Repositories.Interfaces;

public interface IAchievementsRepository : IGenericRepository<Achievements>
{
    Task<Achievements?> GetDriverAchievementsAsync(Guid driverId);
}
