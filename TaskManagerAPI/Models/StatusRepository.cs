using System;
using System.Linq;

namespace TaskManagerAPI.Models
{
    public class StatusRepository
    {
        private TaskManagerDbContext _context;

        public StatusRepository(TaskManagerDbContext context)
        {
            _context = context;
        }

        public IQueryable<Status> GetStatuses() => _context.Statuses;
        
        public Status GetStatus(Guid id) => _context.Statuses.Find(id);
    }
}