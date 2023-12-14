using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Models.Interfaces;

namespace TaskManagerAPI.Models
{
    public class TaskRepository : IRepository<Models.TaskModel>
    {
        private TaskManagerDbContext _context;

        public TaskRepository(TaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<TaskModel>> GetAsync() => 
            _context.Tasks.Include(t=>t.Status) ;

        public async Task<TaskModel> GetAsync(Guid id) => _context.Tasks
            .Include(t => t.Status)
            .FirstOrDefault(t => t.Id == id);

        public async Task<TaskModel> PostAsync(TaskModel item)
        {
            _context.Tasks.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(TaskModel item)
        {
            _context.Tasks.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task PutAsync(Guid id, TaskModel item)
        {
            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (ItemExist(id))
                    throw;
            }
        }

        private bool ItemExist(Guid id) => _context.Tasks.Any(t=>t.Id==id);
    }
}