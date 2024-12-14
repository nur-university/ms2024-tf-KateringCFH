using Microsoft.EntityFrameworkCore;
using ServicioCatering.Domain.NutritionalPlans;
using ServicioCatering.Infrastructure.Abstractions.Repositories;
using ServicioCatering.Infrastructure.DomainModel;
using System;
using System.Threading.Tasks;

namespace ServicioCatering.Infrastructure.Repositories;

internal class NutritionPlanRepository : INutritionPlanRepository
{
    private readonly DomainDbContext _dbContext;

    public NutritionPlanRepository(DomainDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(NutritionPlan nutritionPlan)
    {
        await _dbContext.NutritionPlans.AddAsync(nutritionPlan);
    }

    public async Task UpdateAsync(NutritionPlan nutritionPlan)
    {
        _dbContext.NutritionPlans.Update(nutritionPlan);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<NutritionPlan?> GetByIdAsync(Guid id)
    {
        return await _dbContext.NutritionPlans
                               .Include(n => n.Recipes)
                               .FirstOrDefaultAsync(n => n.Id == id);
    }

    public async Task<NutritionPlan?> GetByNameAsync(string name)
    {
        return await _dbContext.NutritionPlans
                               .FirstOrDefaultAsync(n => n.Name == name);
    }
}
