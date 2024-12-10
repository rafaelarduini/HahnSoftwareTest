using HahnSoftwareTest.Application.Interfaces;
using HahnSoftwareTest.Application.Services;
using HahnSoftwareTest.Infrastructure.Data;
using HahnSoftwareTest.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAdviceSlipRepository, AdviceSlipRepository>();
builder.Services.AddScoped<IAdviceSlipRepositoryService, AdviceSlipRepositoryService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
