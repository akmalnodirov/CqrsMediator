namespace CqrsMediator.Entities.DbSet;

public class Driver : BaseEntity
{
    public Driver()
    {
        Achievements = new HashSet<Achievements>();
    }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int DriverNumber { get; set; }
    public DateTime DateOfBirth { get; set; }

    public virtual ICollection<Achievements> Achievements { get; set; }
}
