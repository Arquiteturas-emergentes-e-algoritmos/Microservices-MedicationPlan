﻿using MedicationPlan.Persistence.Config;
using Microsoft.EntityFrameworkCore;

namespace MedicationPlan.Persistence;

public class MedicationPlanDbContext : DbContext
{
    public MedicationPlanDbContext(DbContextOptions<MedicationPlanDbContext> options) : base(options) { }

    public DbSet<Domain.Entities.MedicationPlan> MedicationPlans { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<Domain.Entities.MedicationPlan>(new MedicationPlanConfig());
    }
}
