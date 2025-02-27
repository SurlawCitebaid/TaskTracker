using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Models
{
    public class TaskTrackerDbContext : DbContext
    {
        public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> options) : base(options) { }
        public DbSet<User>? Users { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
    }
}

