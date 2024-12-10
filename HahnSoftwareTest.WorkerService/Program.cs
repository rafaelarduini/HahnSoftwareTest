using HahnSoftwareTest.Application.Interfaces;
using HahnSoftwareTest.Application.Services;
using HahnSoftwareTest.Infrastructure.Data;
using HahnSoftwareTest.Infrastructure.Repositories;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found in configuration.");
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddHangfire(config =>
    config.UseSqlServerStorage(connectionString));

builder.Services.AddHangfireServer();

builder.Services.AddHttpClient();

builder.Services.AddScoped<IExternalApiService, ExternalApiService>();
builder.Services.AddScoped<IAdviceSlipRepository, AdviceSlipRepository>();
builder.Services.AddScoped<IAdviceSlipRepositoryService, AdviceSlipRepositoryService>();
builder.Services.AddScoped<IDataUpsertService, DataUpsertService>();

builder.Services.AddHostedService<Worker>();

var app = builder.Build();

app.UseHangfireDashboard();

app.Run();
