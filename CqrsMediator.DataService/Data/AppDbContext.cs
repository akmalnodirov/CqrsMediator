using CqrsMediator.Entities.DbSet;
using Microsoft.EntityFrameworkCore;

namespace CqrsMediator.DataService.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    //Defining the db entities
    public virtual DbSet<Driver> Drivers { get; set; }
    public virtual DbSet<Achievements> Achievements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //specifying the relationship
        modelBuilder.Entity<Achievements>(entity =>
        {
            entity.HasOne(d => d.Driver)
            .WithMany(p => p.Achievements)
            .HasForeignKey(c => c.DriverId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_achievements_Driver");
        });
    }
}
