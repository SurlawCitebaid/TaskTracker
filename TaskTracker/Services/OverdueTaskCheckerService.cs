using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskTracker.Models;

public class OverdueTaskCheckerService : BackgroundService
{
    private readonly IServiceProvider _services;

    public OverdueTaskCheckerService(IServiceProvider services)
    {
        _services = services;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<TaskTrackerDbContext>();

                var overdueTasks = dbContext.Tasks
                    .Where(t => t.DueDate < DateTime.Now && !t.IsCompleted)
                    .ToList();

                foreach (var taskItem in overdueTasks)
                {
                    Console.WriteLine($"Overdue Task Found: {taskItem.Title}");
                }
            }

            // Wait 1 minute before checking again
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}