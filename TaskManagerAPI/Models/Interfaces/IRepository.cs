using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerAPI.Models.Interfaces
{
    public interface IRepository<T>
    {
        Task<IQueryable<T>> GetAsync();
        Task<T> GetAsync(Guid id);
        Task<T> PostAsync(T item);
        Task DeleteAsync(T item);
        Task PutAsync(Guid id, T item);
    }
}