using HahnSoftwareTest.Infrastructure.Data;
using HahnSoftwareTest.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;

public class DataUpsertService : IDataUpsertService
{
    private readonly IServiceProvider _serviceProvider;

    public DataUpsertService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task PerformDataUpsert()
    {
        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var myEntity = new MyEntity
        {
            Name = "Sample Data"
        };

        context.MyEntities.Add(myEntity);
        await context.SaveChangesAsync();
    }
}