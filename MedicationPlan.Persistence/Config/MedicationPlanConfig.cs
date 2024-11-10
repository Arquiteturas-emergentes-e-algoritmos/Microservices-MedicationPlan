using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicationPlan.Persistence.Config;

public class MedicationPlanConfig : IEntityTypeConfiguration<Domain.Entities.MedicationPlan>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.MedicationPlan> builder)
    {
        builder.HasKey(x => x.Id);
        builder.OwnsMany(u => u.Medications);
    }
}
