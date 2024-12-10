using HahnSoftwareTest.Application.Interfaces;
using Hangfire;

public class Worker : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        RecurringJob.AddOrUpdate<IDataUpsertService>(
            "data-upsert-job",
            service => service.PerformDataUpsertAsync(),
            Cron.Hourly,
            new RecurringJobOptions
            {
                TimeZone = TimeZoneInfo.Local
            });

        await Task.CompletedTask;
    }
}
