using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using RestSharp;

namespace TaskManagerClient.Models.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAsync();
        
        Task<T> GetAsync(Guid id);
        
        Task<HttpStatusCode> PostAsync(PostTaskRequestModel item);
        
        Task<ResponseStatus> DeleteAsync(Guid id);
        
        Task<HttpStatusCode> PutAsync(Guid id, T item);
    }
}