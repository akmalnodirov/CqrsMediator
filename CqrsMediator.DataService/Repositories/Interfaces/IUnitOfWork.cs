namespace CqrsMediator.DataService.Repositories.Interfaces;

public interface IUnitOfWork
{
    IDriverRepository DriverRepository { get; }
    IAchievementsRepository AchievementsRepository { get; }

    Task<bool> CompleteAsync();
}
