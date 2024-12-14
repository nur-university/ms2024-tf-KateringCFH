using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicioCatering.Domain.NutritionalPlans;

namespace ServicioCatering.Infrastructure.Configurations;

internal class NutritionPlanConfig : IEntityTypeConfiguration<NutritionPlan>
{
    public void Configure(EntityTypeBuilder<NutritionPlan> builder)
    {
        builder.ToTable("NutritionPlans");

        builder.HasKey(n => n.Id);

        builder.Property(n => n.Name)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(n => n.Objectives)
               .HasMaxLength(500);

        builder.HasMany(n => n.Recipes)
               .WithOne()
               .HasForeignKey("NutritionPlanId")
               .OnDelete(DeleteBehavior.Cascade);
    }
}
