using CqrsMediator.DataService.Data;
using CqrsMediator.DataService.Repositories.Interfaces;
using CqrsMediator.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CqrsMediator.DataService.Repositories;

public class DriverRepository(AppDbContext context, ILogger logger) : GenericRepository<Driver>(context, logger), IDriverRepository
{
    public override async Task<IEnumerable<Driver>> All()
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

    public override async Task<bool> Update(Driver driver)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == driver.Id);
        if (entity != null)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            entity.DriverNumber = driver.DriverNumber;
            entity.FirstName = driver.FirstName;
            entity.LastName = driver.LastName;
            entity.DateOfBirth = driver.DateOfBirth;

            return true;
        }

        return false;
    }
}
