using Application.Interfaces;
using Hangfire;

public class Worker : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        RecurringJob.AddOrUpdate<IDataUpsertService>(
            "data-upsert-job",
            service => service.PerformDataUpsert(),
            Cron.Minutely,
            new RecurringJobOptions
            {
                TimeZone = TimeZoneInfo.Local
            });

        await Task.CompletedTask;
    }
}
