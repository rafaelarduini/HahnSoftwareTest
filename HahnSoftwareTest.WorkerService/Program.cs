using HahnSoftwareTest.Infrastructure.Data;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using HahnSoftwareTest.Infrastructure.Repositories;
using HahnSoftwareTest.Domain.Entities;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices((hostContext, services) =>
{
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection")));

    services.AddScoped<IRepository<MyEntity>, MyEntityRepository>();

    services.AddHangfire(x => x.UseSqlServerStorage(hostContext.Configuration.GetConnectionString("DefaultConnection")));
    services.AddHangfireServer();

    services.AddHostedService<Worker>();
});

var app = builder.Build();

await app.RunAsync();
