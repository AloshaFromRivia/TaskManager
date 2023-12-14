using System;

namespace TaskManagerAPI.Models.Requests
{
    public class PutTaskRequest
    {
        public Guid Id { get; set; }
        public TaskModel TaskModel { get; set; }
    }
}