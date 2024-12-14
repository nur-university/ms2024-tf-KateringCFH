using Microsoft.EntityFrameworkCore;
using ServicioCatering.Domain.CateringContracts;
using ServicioCatering.Domain.NutritionalPlans;

namespace ServicioCatering.Infrastructure.DomainModel;

internal class DomainDbContext : DbContext
{
    public DbSet<CateringContract> CateringContracts { get; set; }
    public DbSet<NutritionPlan> NutritionPlans { get; set; }

    public DomainDbContext(DbContextOptions<DomainDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DomainDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
