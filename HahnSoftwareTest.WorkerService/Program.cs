using Application.Interfaces;
using HahnSoftwareTest.Infrastructure.Data;
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

builder.Services.AddScoped<IDataUpsertService, DataUpsertService>();

builder.Services.AddHostedService<Worker>();

var app = builder.Build();

app.UseHangfireDashboard();

app.Run();
