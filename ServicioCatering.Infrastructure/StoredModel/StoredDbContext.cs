using Microsoft.EntityFrameworkCore;
using ServicioCatering.Infrastructure.StoredModel.Entities;

namespace ServicioCatering.Infrastructure.StoredModel;

internal class StoredDbContext : DbContext
{
    public DbSet<CateringContractStoredModel> CateringContracts { get; set; }
    public DbSet<NutritionPlanStoredModel> NutritionPlans { get; set; }

    public StoredDbContext(DbContextOptions<StoredDbContext> options) : base(options) { }
}
