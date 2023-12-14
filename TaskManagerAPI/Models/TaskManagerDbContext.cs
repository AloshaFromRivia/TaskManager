
using Microsoft.EntityFrameworkCore;

namespace TaskManagerAPI.Models
{
    public class TaskManagerDbContext : DbContext
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : base(options)
        {
            
        }

        public DbSet<Models.TaskModel> Tasks { get; set; }
        public DbSet<Status> Statuses { get; set; }
       
    }
}