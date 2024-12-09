using Hangfire;
using HahnSoftwareTest.Infrastructure.Data;
using HahnSoftwareTest.Domain.Entities;

public class Worker : BackgroundService
{
    private readonly ApplicationDbContext _context;
    private readonly IRecurringJobManager _recurringJobManager;
    private readonly IConfiguration _configuration;

    public Worker(ApplicationDbContext context, IRecurringJobManager recurringJobManager, IConfiguration configuration)
    {
        _context = context;
        _recurringJobManager = recurringJobManager;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        string? connectionString = _configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found in configuration.");
        }

        GlobalConfiguration.Configuration
            .UseSqlServerStorage(connectionString);

        var recurringJobOptions = new RecurringJobOptions
        {
            TimeZone = TimeZoneInfo.Local
        };

        _recurringJobManager.AddOrUpdate(
            "data-upsert-job", 
            () => PerformDataUpsert(),
            "0 * * * *",
            recurringJobOptions);

        await Task.CompletedTask;
    }

    public async Task PerformDataUpsert()
    {
        var myEntity = new MyEntity
        {
            Name = "Sample Data"
        };

        _context.MyEntities.Add(myEntity);

        await _context.SaveChangesAsync();
    }
}
