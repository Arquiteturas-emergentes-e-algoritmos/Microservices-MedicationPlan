using MedicationPlan.Application.Repository;
using MedicationPlan.Application.Services;
using MedicationPlan.Persistence;
using MedicationPlan.Persistence.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IMedicationPlanRepository, MedicationPlanRepository>();
builder.Services.AddTransient<MedicationPlanService>();

builder.Services.AddDbContext<MedicationPlanDbContext>(options =>
{
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
