using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RestSharp;
using TaskManagerClient.Models.Interfaces;

namespace TaskManagerClient.Models
{
    public class TaskRepository : IRepository<Models.TaskModel>
    {
        private RestClientOptions _options;

        public TaskRepository(RestClientOptions options)
        {
            _options = options;
        }
        
        public async Task<List<Models.TaskModel>> GetAsync()
        {
            var client = new RestClient(_options);
            
            return await client.GetJsonAsync<List<Models.TaskModel>>("api/task");
        }

        public async Task<TaskModel> GetAsync(Guid id)
        {
            var client = new RestClient(_options);
            
            return await client.GetJsonAsync<Models.TaskModel>($"api/task/{id}");
        }
        
        public async Task<HttpStatusCode> PostAsync(PostTaskRequestModel item)
        {
            var client = new RestClient(_options);
            
            var result = await client.PostJsonAsync<PostTaskRequestModel>("api/task/", item);

            return result;
        }

        public async Task<ResponseStatus> DeleteAsync(Guid id)
        {
            var client = new RestClient(_options);
            
            var request = new RestRequest($"api/task/{id}");
            
            var result = await client.DeleteAsync(request);

            return result.ResponseStatus;
        }

        
        public async Task<HttpStatusCode> PutAsync(Guid id, TaskModel item)
        {
            var client = new RestClient(_options);
            var request = new RestRequest("api/task/",Method.Put);

            request.AddBody(new PutTaskRequest()
            {
                Id = id,
                TaskModel = item
            },ContentType.Json);

            var result = await client.ExecuteAsync(request);

            return result.StatusCode;
        }
    }
}