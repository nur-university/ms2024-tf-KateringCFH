using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicioCatering.Domain.CateringContracts;

namespace ServicioCatering.Infrastructure.Configurations;

internal class CateringContractConfig : IEntityTypeConfiguration<CateringContract>
{
    public void Configure(EntityTypeBuilder<CateringContract> builder)
    {
        builder.ToTable("CateringContracts");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.PatientId)
               .IsRequired();

        builder.Property(c => c.NutritionPlanId)
               .IsRequired();

        builder.OwnsOne(c => c.DeliveryCalendar, calendar =>
        {
            calendar.ToTable("DeliveryCalendars");
            calendar.Property(c => c.DeliveryDates)
                    .HasColumnName("Dates")
                    .IsRequired();
        });

        builder.HasMany(c => c.Deliveries)
               .WithOne()
               .HasForeignKey("CateringContractId")
               .OnDelete(DeleteBehavior.Cascade);
    }
}
