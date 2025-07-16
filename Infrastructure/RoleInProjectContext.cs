using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class RoleInProjectContext : DbContext
{
    public virtual DbSet<RoleInProjectDataModel> RoleInProjects { get; set; }

    public RoleInProjectContext(DbContextOptions<RoleInProjectContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleInProjectDataModel>()
                .OwnsOne(a => a.Period);

            base.OnModelCreating(modelBuilder);
        }
}
